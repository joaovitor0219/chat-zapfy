using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplicativoTarefa.Dominio.Execoes;
using ChatZapfy.Dominio.ConversasUsuarios.Entidades;
using ChatZapfy.Dominio.ConversasUsuarios.Servicos.Interfaces;
using ChatZapfy.Dominio.Usuarios.Entidades;
using ChatZapfy.Dominio.Usuarios.Repositorios.Interfaces;
using ChatZapfy.Dominio.Usuarios.Servicos.Comandos;
using ChatZapfy.Dominio.Usuarios.Servicos.Interfaces;

namespace ChatZapfy.Dominio.Usuarios.Servicos
{
    public class UsuariosServico : IUsuariosServico
    {
        private readonly IUsuariosRepositorio usuariosRepositorio;
        private readonly IConversasUsuariosServico conversasUsuariosServico;

        public UsuariosServico(IUsuariosRepositorio usuariosRepositorio, IConversasUsuariosServico conversasUsuariosServico)
        {
            this.usuariosRepositorio = usuariosRepositorio;
            this.conversasUsuariosServico = conversasUsuariosServico;
        }

        public Usuario Editar(int id, UsuarioComando comando)
        {
            Usuario usuario = Validar(id);

            usuario.SetNome(comando.Nome);
            usuario.SetEmail(comando.Email);
            usuario.SetSenha(comando.Senha);

            return usuario;
        }

        public void Excluir(int id)
        {
            Usuario usuario = Validar(id);

            usuariosRepositorio.Excluir(usuario);
        }

        public void Inserir(UsuarioComando comando)
        {
            Usuario usuario = Instanciar(comando);

            usuariosRepositorio.Inserir(usuario);
        }

        public Usuario Instanciar(UsuarioComando comando)
        {
            Usuario usuario = new Usuario(comando.Nome, comando.Email, comando.Senha);

            return usuario;
        }

        public Usuario Validar(int id)
        {
            Usuario usuario = usuariosRepositorio.Recuperar(id);

            if (usuario is null)
                throw new RegraDeNegocioExcecao("Usuário não encontrado");

            return usuario;
        }

        public IList<Usuario> RecuperarUsuariosPorConversa(int idConversa)
        {
            IList<ConversaUsuario> conversaUsuarios = conversasUsuariosServico.RecuperarConversaUsuarioPorConversa(idConversa);

            IList<Usuario> usuarios = new List<Usuario>();

            foreach (var conversaUsuario in conversaUsuarios)
            {
                Usuario usuario = Validar(conversaUsuario.Usuario.Id);

                usuarios.Add(usuario);
            }

            return usuarios;
        }

        public Usuario RecuperarUsuarioLogin(string nome, string senha)
        {
            return usuariosRepositorio.RecuperarUsuarioLogin(nome, senha);
        }
    }
}