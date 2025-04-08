using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoglass.Autoplay.Dominio.Util;
using Autoglass.Autoplay.Dominio.Util.Filtros.Enumeradores;
using ChatZapfy.Dominio.ConversasUsuarios.Entidades;
using ChatZapfy.Dominio.Genericos.Interfaces;
using ChatZapfy.Dominio.Usuarios.Entidades;
using ChatZapfy.Dominio.Usuarios.Repositorios.Filtros;
using ChatZapfy.Dominio.Usuarios.Repositorios.Interfaces;
using ChatZapfy.Infra.Genericos;
using NHibernate;

namespace ChatZapfy.Infra.Usuarios.Repositorios
{
    public class UsuariosRepositorio : GenericoRepositorio<Usuario>, IUsuariosRepositorio
    {
        public UsuariosRepositorio(ISession session) : base(session)
        {
        }

        public IQueryable<Usuario> Filtrar(UsuarioListarFiltro filtro)
        {
            var query = Query();

            if(filtro.Id.HasValue)
            {
                query = query.Where(x => x.Id == filtro.Id.Value);
            }

            if(!string.IsNullOrWhiteSpace(filtro.Email))
            {
                query = query.Where(x => x.Email.Trim().ToUpper().Contains(filtro.Email.Trim().ToUpper()));
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