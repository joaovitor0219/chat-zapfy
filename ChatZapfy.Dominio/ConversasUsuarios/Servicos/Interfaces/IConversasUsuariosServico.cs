using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatZapfy.Dominio.Conversas.Entidades;
using ChatZapfy.Dominio.ConversasUsuarios.Entidades;
using ChatZapfy.Dominio.Usuarios.Entidades;

namespace ChatZapfy.Dominio.ConversasUsuarios.Servicos.Interfaces
{
    public interface IConversasUsuariosServico
    {
        void Inserir(Usuario usuario, Conversa conversa);
        ConversaUsuario Instanciar(Usuario usuario, Conversa conversa);
        void Excluir(int id);
        ConversaUsuario Validar(int id);
        IList<ConversaUsuario> RecuperarConversaUsuarioPorConversa(int idConversa);
    }
}