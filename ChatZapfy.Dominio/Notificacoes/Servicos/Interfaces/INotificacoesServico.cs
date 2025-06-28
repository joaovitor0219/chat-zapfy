using ChatZapfy.Dominio.Notificacoes.Servicos.Comandos;

namespace ChatZapfy.Dominio.Notificacoes.Servicos.Interfaces;

public interface INotificacoesServico
{
    Task CriarNotificaoAsync(NotificacaoComando comando);
}
