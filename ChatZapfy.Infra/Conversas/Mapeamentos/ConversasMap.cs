using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatZapfy.Dominio.Conversas.Entidades;
using FluentNHibernate.Mapping;

namespace ChatZapfy.Infra.Conversas.Mapeamentos
{
    public class ConversasMap : ClassMap<Conversa>
    {
        public ConversasMap()
        {
            Schema("CHATZAPFY");
            Table("CONVERSA");
            Id(x => x.Id).Column("ID");
            Map(x => x.Grupo).Column("GRUPO");
            Map(x => x.Nome).Column("NOME");
            Map(x => x.DataInclusao).Column("DATAINCLUSAO");
            HasMany(x => x.ConversasUsuarios)
            .KeyColumn("IDCONVERSA")
            .Inverse()
            .Cascade.All();

        }
        
    }
}