using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatZapfy.Dominio.Usuarios.Entidades;
using FluentNHibernate.Mapping;

namespace ChatZapfy.Infra.Usuarios.Mapeamentos
{
    public class UsuariosMap : ClassMap<Usuario>
    {
        public UsuariosMap()
        {
            Schema("CHATZAPFY");
            Table("USUARIO");
            Id(u => u.Id).Column("id");
            Map(u => u.Nome).Column("Nome");
            Map(u => u.Email).Column("Email");
            Map(u => u.Senha).Column("Senha");
            Map(u => u.DataInclusao).Column("DataInclusao");
            HasMany(x => x.ConversasUsuarios).KeyColumn("IDUSUARIO").Inverse().Cascade.All();
        }
    }
}