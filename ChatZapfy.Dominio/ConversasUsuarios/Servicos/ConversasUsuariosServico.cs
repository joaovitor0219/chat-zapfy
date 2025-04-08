using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using AplicativoTarefa.Dominio.Execoes;
using ChatZapfy.Dominio.Conversas.Entidades;
using ChatZapfy.Dominio.ConversasUsuarios.Entidades;
using ChatZapfy.Dominio.ConversasUsuarios.Repositorios;
using ChatZapfy.Dominio.ConversasUsuarios.Servicos.Interfaces;
using ChatZapfy.Dominio.Usuarios.Entidades;

namespace ChatZapfy.Dominio.ConversasUsuarios.Servicos
{
    public class ConversasUsuariosServico : IConversasUsuariosServico
    {
        private readonly IConversasUsuariosRepositorio conversasUsuariosRepositorio;

        public ConversasUsuariosServico(IConversasUsuariosRepositorio conversasUsuariosRepositorio)
        {
            this.conversasUsuariosRepositorio = conversasUsuariosRepositorio;
        }

        public void Excluir(int id)
        {
            var conversaUsuario = Validar(id);

            conversasUsuariosRepositorio.Excluir(conversaUsuario);
        }

        public void Inserir(Usuario usuario, Conversa conversa)
        {
            var conversaUsuario = Instanciar(usuario, conversa);

            conversasUsuariosRepositorio.Inserir(conversaUsuario);
        }

        public ConversaUsuario Instanciar(Usuario usuario, Conversa conversa)
        {
            return new ConversaUsuario(usuario, conversa);
        }

        public ConversaUsuario Validar(int id)
        {
            var conversaUsuario = conversasUsuariosRepositorio.Recuperar(id);

            if(conversaUsuario is null)
                throw new RegraDeNegocioExcecao("Conversa usuario é obrigatório");

            return conversaUsuario;
        }

        public IList<ConversaUsuario> RecuperarConversaUsuarioPorConversa(int idConversa)
        {
            IList<ConversaUsuario> conversaUsuarios = conversasUsuariosRepositorio.RecuperarConversasUsuariosPorConversa(idConversa);

            return conversaUsuarios;
        }
    }
}