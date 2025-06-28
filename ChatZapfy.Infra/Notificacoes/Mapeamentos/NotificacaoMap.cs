using FluentNHibernate.Mapping;
using ChatZapfy.Dominio.Notificacoes.Entidades;

namespace ChatZapfy.Infra.Notificacoes.Mapeamentos;

public class NotificacaoMap : ClassMap<Notificacao>
{
    public NotificacaoMap()
    {
        Schema("CHATZAPFY");
        Table("NOTIFICACAO");
        Id(x => x.Id).Column("ID");
        References(x => x.Conversa).Column("IDCONVERSA");
        References(x => x.Usuario).Column("IDUSUARIO");
        References(x => x.Mensagem).Column("IDMENSAGEM");
        Map(x => x.DataCriacao).Column("DATACRIACAO");
        Map(x => x.Visualizada).Column("VISUALIZADA");
    }
}
