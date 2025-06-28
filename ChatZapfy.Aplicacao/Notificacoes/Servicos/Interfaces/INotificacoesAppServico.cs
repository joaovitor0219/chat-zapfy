using ChatZapfy.DataTransfer.Notificacoes.Requests.Requests;

namespace ChatZapfy.Aplicacao.Notificacoes.Servicos.Interfaces;

public interface INotificacoesAppServico
{
    Task CriarNotificaoAsync(NotificacaoRequest request);
}
