using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatZapfy.Dominio.ConversasUsuarios.Entidades;
using ChatZapfy.Dominio.ConversasUsuarios.Repositorios;
using ChatZapfy.Infra.Genericos;
using NHibernate;

namespace ChatZapfy.Infra.ConversasUsuarios.Repositorios
{
    public class ConversasUsuariosRepositorio : GenericoRepositorio<ConversaUsuario>, IConversasUsuariosRepositorio
    {
        public ConversasUsuariosRepositorio(ISession session) : base(session)
        {
        }
    }
}