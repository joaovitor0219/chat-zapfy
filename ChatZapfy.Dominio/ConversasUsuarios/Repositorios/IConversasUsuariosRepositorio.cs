using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatZapfy.Dominio.ConversasUsuarios.Entidades;
using ChatZapfy.Dominio.ConversasUsuarios.Repositorios.Filtros;
using ChatZapfy.Dominio.Genericos.Interfaces;

namespace ChatZapfy.Dominio.ConversasUsuarios.Repositorios
{
    public interface IConversasUsuariosRepositorio : IGenericoRepositorio<ConversaUsuario>
    {
        IQueryable<ConversaUsuario> Filtrar(ConversaUsuarioListarFiltro filtro);
        IList<ConversaUsuario> RecuperarConversasUsuariosPorConversa(int idConversa);
        IList<ConversaUsuario> RecuperarConversasUsuariosPorUsuario(int idUsuario);
    }
}