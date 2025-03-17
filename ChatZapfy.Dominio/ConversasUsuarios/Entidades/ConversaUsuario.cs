using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatZapfy.Dominio.Conversas.Entidades;
using ChatZapfy.Dominio.Usuarios.Entidades;

namespace ChatZapfy.Dominio.ConversasUsuarios.Entidades
{
    public class ConversaUsuario
    {
        public int Id { get; protected set; }
        public Usuario Usuario { get; protected set; }
        public Conversa Conversa { get; protected set; }
        public DateTime DataInclusao { get; protected set; }

        protected ConversaUsuario()
        {
            
        }

        public ConversaUsuario(Usuario usuario, Conversa conversa)
        {
            SetUsuario(usuario);
            SetConversa(conversa);
            DataInclusao = DateTime.Now;
        }

        public virtual void SetUsuario(Usuario usuario)
        {
            Usuario = usuario;
        }
        public virtual void SetConversa(Conversa conversa)
        {
            Conversa = conversa;
        }
        
    }
}