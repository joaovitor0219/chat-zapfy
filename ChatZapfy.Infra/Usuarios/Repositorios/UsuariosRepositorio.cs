using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoglass.Autoplay.Dominio.Util;
using Autoglass.Autoplay.Dominio.Util.Filtros.Enumeradores;
using ChatZapfy.Dominio.Genericos.Interfaces;
using ChatZapfy.Dominio.Usuarios.Entidades;
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

    }
}