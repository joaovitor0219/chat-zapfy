using Amazon.Runtime.Internal.Util;
using Autoglass.Autoplay.Aplicacao.Transacoes.Interfaces;
using AutoMapper;
using ChatZapfy.Aplicacao.Notificacoes.Servicos.Interfaces;
using ChatZapfy.DataTransfer.Notificacoes.Requests.Requests;
using ChatZapfy.Dominio.Notificacoes.Servicos.Comandos;
using ChatZapfy.Dominio.Notificacoes.Servicos.Interfaces;
using Microsoft.Extensions.Logging;

namespace ChatZapfy.Aplicacao.Notificacoes.Servicos;

public class NotificacoesAppServico : INotificacoesAppServico
{
    private readonly INotificacoesServico notificacoesServico;
    private readonly IUnitOfWork unitOfWork;
    private readonly ILogger<NotificacoesAppServico> logger;
    private readonly IMapper mapper;

    public NotificacoesAppServico(INotificacoesServico notificacoesServico, IUnitOfWork unitOfWork, ILogger<NotificacoesAppServico> logger, IMapper mapper)
    {
        this.notificacoesServico = notificacoesServico;
        this.unitOfWork = unitOfWork;
        this.logger = logger;
        this.mapper = mapper;
    }

    public async Task CriarNotificaoAsync(NotificacaoRequest request)
    {
        NotificacaoComando comando = mapper.Map<NotificacaoComando>(request);

        try
        {
            unitOfWork.BeginTransaction();

            await notificacoesServico.CriarNotificaoAsync(comando);

            unitOfWork.Commit();

        }
        catch (Exception ex)
        {
            unitOfWork.Rollback();

            logger.LogError(ex, "<{EventoId} {Mensagem}>", "CriarNotificaoAsync", "Erro ao inserir notificações");

            throw;
        }
    }
}
