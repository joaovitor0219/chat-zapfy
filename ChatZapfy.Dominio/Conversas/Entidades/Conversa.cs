using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatZapfy.Dominio.ConversasUsuarios.Entidades;

namespace ChatZapfy.Dominio.Conversas.Entidades
{
    public class Conversa
    {
        public virtual int Id { get; protected set; }
        public virtual bool Grupo { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual DateTime DataInclusao { get; protected set; }
        public virtual IList<ConversaUsuario> ConversasUsuarios { get; set; } = new List<ConversaUsuario>();

        protected Conversa()
        {
            
        }

        public Conversa(bool grupo, string nome)
        {
            SetGrupo(grupo);
            SetNome(nome);
            DataInclusao = DateTime.Now;
        }

        public virtual void SetGrupo(bool grupo)
        {
            Grupo = grupo;
        }

        public virtual void SetNome(string nome)
        {
            Nome = nome;
        }

    }
}