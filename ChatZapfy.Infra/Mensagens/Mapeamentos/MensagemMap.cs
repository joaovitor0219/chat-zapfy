using FluentNHibernate.Mapping;
using ChatZapfy.Dominio.Mensagens.Entidades;

namespace ChatZapfy.Infra.Mensagens.Mapeamentos;

public class MensagemMap : ClassMap<Mensagem>
{
    public MensagemMap()
    {
        Schema("CHATZAPFY");
        Table("MENSAGEM");
        Id(x => x.Id).Column("ID");
        References(x => x.Conversa).Column("IDCONVERSA");
        References(x => x.Usuario).Column("IDUSUARIO");
        Map(x => x.DataEnvio).Column("DATAENVIO");
        Map(x => x.Conteudo).Column("CONTEUDO");
    }
}
