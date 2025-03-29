using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatZapfy.Dominio.Genericos.Interfaces;
using ChatZapfy.Dominio.Usuarios.Entidades;
using ChatZapfy.Dominio.Usuarios.Repositorios.Filtros;

namespace ChatZapfy.Dominio.Usuarios.Repositorios.Interfaces
{
    public interface IUsuariosRepositorio : IGenericoRepositorio<Usuario>
    {
        IQueryable<Usuario> Filtrar(UsuarioListarFiltro filtro);
    }
}