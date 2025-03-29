using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatZapfy.Dominio.Conversas.Entidades;
using ChatZapfy.Dominio.Conversas.Repositorios;
using ChatZapfy.Dominio.Conversas.Repositorios.Filtros;
using ChatZapfy.Infra.Genericos;
using NHibernate;

namespace ChatZapfy.Infra.Conversas.Repositorios
{
    public class ConversasRepositorio : GenericoRepositorio<Conversa>, IConversasRepositorio
    {
        public ConversasRepositorio(ISession session) : base(session)
        {
        }

        public IQueryable<Conversa> Filtrar(ConversaListarFiltro filtro)
        {
            var query = Query();

            if(filtro.Id.HasValue)
            {
                query = query.Where(x => x.Id == filtro.Id.Value);
            }

            if(filtro.Grupo.HasValue)
            {
                query = query.Where(x => x.Grupo == filtro.Grupo.Value);
            }

            if(!string.IsNullOrWhiteSpace(filtro.Nome))
            {
                query = query.Where(x => x.Nome.Trim().ToUpper().Contains(filtro.Nome.Trim().ToUpper()));
            }

            if(filtro.DataInclusao.HasValue)
            {
                query = query.Where(x => x.DataInclusao == filtro.DataInclusao.Value);
            }

            return query;
        }
    }
}