using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatZapfy.Dominio.ConversasUsuarios.Entidades;
using ChatZapfy.Dominio.ConversasUsuarios.Repositorios;
using ChatZapfy.Dominio.ConversasUsuarios.Repositorios.Filtros;
using ChatZapfy.Infra.Genericos;
using NHibernate;

namespace ChatZapfy.Infra.ConversasUsuarios.Repositorios
{
    public class ConversasUsuariosRepositorio : GenericoRepositorio<ConversaUsuario>, IConversasUsuariosRepositorio
    {
        public ConversasUsuariosRepositorio(ISession session) : base(session)
        {
        }

        public IQueryable<ConversaUsuario> Filtrar(ConversaUsuarioListarFiltro filtro)
        {
            var query = Query();

            if (filtro.IdConversa.HasValue)
            {
                query = query.Where(x => x.Conversa.Id == filtro.IdConversa.Value);
            }

            if (filtro.IdUsuario.HasValue)
            {
                query = query.Where(x => x.Usuario.Id == filtro.IdUsuario.Value);
            }

            if (filtro.Id.HasValue)
            {
                query = query.Where(x => x.Id == filtro.Id.Value);
            }

            if (filtro.DataInclusao.HasValue)
            {
                query = query.Where(x => x.DataInclusao == filtro.DataInclusao.Value);
            }

            return query;
        }

        public IList<ConversaUsuario> RecuperarConversasUsuariosPorConversa(int idConversa)
        {
            IList<ConversaUsuario> conversaUsuarios = Query().Where(x => x.Conversa.Id == idConversa).ToList();

            return conversaUsuarios;
        }
        
        public IList<ConversaUsuario> RecuperarConversasUsuariosPorUsuario(int idUsuario)
        {
            IList<ConversaUsuario> conversaUsuarios = Query().Where(x => x.Usuario.Id == idUsuario).ToList();

            return conversaUsuarios;
        }
    }
}