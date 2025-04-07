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
        public virtual int Id { get; protected set; }
        public virtual Usuario Usuario { get; protected set; }
        public virtual Conversa Conversa { get; protected set; }
        public virtual DateTime DataInclusao { get; protected set; }

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