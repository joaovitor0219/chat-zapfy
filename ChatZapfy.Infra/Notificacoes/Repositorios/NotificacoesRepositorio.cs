using ChatZapfy.Dominio.Notificacoes.Repositorios.Interfaces;
using ChatZapfy.Infra.Genericos;
using ChatZapfy.Dominio.Notificacoes.Entidades;
using NHibernate;

namespace ChatZapfy.Infra.Notificacoes.Repositorios;

public class NotificacoesRepositorio : GenericoRepositorio<Notificacao>, INotificacoesRepositorio
{
    public NotificacoesRepositorio(ISession session) : base(session) { }
}
