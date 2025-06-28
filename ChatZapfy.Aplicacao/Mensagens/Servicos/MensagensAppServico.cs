using System.Text.Json;
using Autoglass.Autoplay.Aplicacao.Transacoes.Interfaces;
using Autoglass.Autoplay.Dominio.Util;
using AutoMapper;
using ChatZapfy.Aplicacao.Mensagens.Servicos.Interfaces;
using ChatZapfy.DataTransfer.Mensagens.Requests;
using ChatZapfy.DataTransfer.Mensagens.Requests.Requests;
using ChatZapfy.DataTransfer.Mensagens.Responses.Responses;
using ChatZapfy.Dominio.Mensagens.Entidades;
using ChatZapfy.Dominio.Mensagens.Producer.Interfaces;
using ChatZapfy.Dominio.Mensagens.Publisher.Interfaces;
using ChatZapfy.Dominio.Mensagens.Repositorios.Filtros;
using ChatZapfy.Dominio.Mensagens.Repositorios.Interfaces;
using ChatZapfy.Dominio.Mensagens.Servicos.Comandos;
using ChatZapfy.Dominio.Mensagens.Servicos.Interfaces;
using Microsoft.Extensions.Logging;

namespace ChatZapfy.Aplicacao.Mensagens.Servicos;

public class MensagensAppServico : IMensagensAppServico
{
    private readonly IMensagensServico mensagensServico;
    private readonly IMensagensRepositorio mensagensRepositorio;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    private readonly IPublisherFilaRepositorio publisherFilaRepositorio;
    private readonly IMensagemProducer mensagemProducer;
    private readonly ILogger<MensagensAppServico> logger;

    public MensagensAppServico(
        IMensagensServico mensagensServico,
        IMensagensRepositorio mensagensRepositorio,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IPublisherFilaRepositorio publisherFilaRepositorio,
        ILogger<MensagensAppServico> logger,
        IMensagemProducer mensagemProducer)
    {
        this.mensagensServico = mensagensServico;
        this.mensagensRepositorio = mensagensRepositorio;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
        this.publisherFilaRepositorio = publisherFilaRepositorio;
        this.logger = logger;
        this.mensagemProducer = mensagemProducer;
    }

    public async Task PublicarNaFilaAws(MensagemRequest request)
    {
        try
        {
            MensagemComando comando = new MensagemComando
            {
                IdConversa = request.IdConversa,
                IdUsuario = request.IdUsuario,
                Conteudo = request.Conteudo
            };

            await publisherFilaRepositorio.PublicarAsync(comando);

            await mensagemProducer.PublicarMensagemConsumer(comando);

            logger.LogInformation("<{EventoId}> - {Mensagem}", "PublicarNaFilaAws", "Mensagem publicada na fila");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "<{EventoId} {Mensagem}>", "PublicarNaFilaAws", "Erro ao publicar mensagem na fila");

            throw;
        }

    }

    public async Task InserirMensagens(string mensagemAws)
    {
        try
        {
            MensagemComando comando = JsonSerializer.Deserialize<MensagemComando>(mensagemAws);

            unitOfWork.BeginTransaction();

            await mensagensServico.Inserir(comando);

            unitOfWork.Commit();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "<{EventoId} {Mensagem}>", "InserirMensagens", "Erro ao processar e inserir mensagem");

            unitOfWork.Rollback();

            throw;
        }
    }

    public MensagemResponse Recuperar(int id)
    {
        var conversa = mensagensServico.Validar(id);

        return mapper.Map<MensagemResponse>(conversa);
    }

    public PaginacaoConsulta<MensagemResponse> Listar(MensagemListarRequest request)
    {
        MensagemListarFiltro filtro = mapper.Map<MensagemListarFiltro>(request);

        IQueryable<Mensagem> query = mensagensRepositorio.Filtrar(filtro);

        PaginacaoConsulta<Mensagem> mensagens = mensagensRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.TpOrd);

        return mapper.Map<PaginacaoConsulta<MensagemResponse>>(mensagens);
    }
}
