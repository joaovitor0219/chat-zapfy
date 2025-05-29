using Autoglass.Autoplay.Aplicacao.Transacoes.Interfaces;
using Autoglass.Autoplay.Dominio.Util;
using AutoMapper;
using ChatZapfy.Aplicacao.Mensagens.Servicos.Interfaces;
using ChatZapfy.DataTransfer.Mensagens.Requests;
using ChatZapfy.DataTransfer.Mensagens.Requests.Requests;
using ChatZapfy.DataTransfer.Mensagens.Responses.Responses;
using ChatZapfy.Dominio.Mensagens.Entidades;
using ChatZapfy.Dominio.Mensagens.Repositorios.Filtros;
using ChatZapfy.Dominio.Mensagens.Repositorios.Interfaces;
using ChatZapfy.Dominio.Mensagens.Servicos.Interfaces;

namespace ChatZapfy.Aplicacao.Mensagens.Servicos;

public class MensagensAppServico : IMensagensAppServico
{
    private readonly IMensagensServico mensagensServico;
    private readonly IMensagensRepositorio mensagensRepositorio;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public MensagensAppServico(
        IMensagensServico mensagensServico,
        IMensagensRepositorio mensagensRepositorio,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        this.mensagensServico = mensagensServico;
        this.mensagensRepositorio = mensagensRepositorio;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public void Inserir(MensagemRequest request)
    {
        try
        {
            unitOfWork.BeginTransaction();

            mensagensServico.Inserir(request.IdConversa, request.IdUsuario, request.Conteudo);

            unitOfWork.Commit();
        }
        catch
        {
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
