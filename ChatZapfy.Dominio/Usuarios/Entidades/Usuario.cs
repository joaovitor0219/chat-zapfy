using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplicativoTarefa.Dominio.Execoes;
using ChatZapfy.Dominio.ConversasUsuarios.Entidades;

namespace ChatZapfy.Dominio.Usuarios.Entidades
{
    public class Usuario
    {
        public virtual int Id { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual string Senha { get; protected set; }
        public virtual DateTime DataInclusao { get; protected set; }
        public virtual IList<ConversaUsuario> ConversasUsuarios { get; set; } = new List<ConversaUsuario>();


        protected Usuario()
        {
            
        }

        public Usuario(string nome, string email, string senha)
        {
            SetNome(nome);
            SetEmail(email);
            SetSenha(senha);
            DataInclusao = DateTime.Now;
        }

        public virtual void SetNome(string nome)
        {
            if(string.IsNullOrWhiteSpace(nome))
            {
                throw new AtributoObrigatorioExcecao("Nome");
            }

            if(nome.Length > 255)
            {
                throw new TamanhoDeAtributoInvalidoExcecao("Nome");
            }

            Nome = nome;
        }

        public virtual void SetEmail(string email)
        {
            if(string.IsNullOrWhiteSpace(email))
            {
                throw new AtributoObrigatorioExcecao("Email");
            }

            if(email.Length > 255)
            {
                throw new TamanhoDeAtributoInvalidoExcecao("Email");
            }

            Email = email;
        }

        public virtual void SetSenha(string senha)
        {
            if(string.IsNullOrWhiteSpace(senha))
            {
                throw new AtributoObrigatorioExcecao("Senha");
            }

            if(senha.Length < 8)
            {
                throw new TamanhoDeAtributoInvalidoExcecao("Senha");
            }

            Senha = senha;
        }
    }
}