using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatZapfy.Dominio.Conversas.Entidades;
using ChatZapfy.Dominio.Conversas.Repositorios;
using ChatZapfy.Infra.Genericos;
using NHibernate;

namespace ChatZapfy.Infra.Conversas.Repositorios
{
    public class ConversasRepositorio : GenericoRepositorio<Conversa>, IConversasRepositorio
    {
        public ConversasRepositorio(ISession session) : base(session)
        {
        }
    }
}