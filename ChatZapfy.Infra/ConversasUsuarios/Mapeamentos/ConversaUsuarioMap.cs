using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatZapfy.Dominio.ConversasUsuarios.Entidades;
using FluentNHibernate.Mapping;

namespace ChatZapfy.Infra.ConversasUsuarios.Mapeamentos
{
    public class ConversaUsuarioMap : ClassMap<ConversaUsuario>
    {
        public ConversaUsuarioMap()
        {
            Schema("CHATZAPFY");
            Table("CONVERSA_USUARIO");
            Id(x => x.Id).Column("ID");
            References(x => x.Usuario).Column("IDUSUARIO");
            References(x => x.Conversa).Column("IDCONVERSA");
            Map(x => x.DataInclusao).Column("DATAINCLUSAO");
        }
    }
}