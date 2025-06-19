using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatZapfy.Dominio.Usuarios.Entidades;
using ChatZapfy.Dominio.Usuarios.Servicos.Comandos;

namespace ChatZapfy.Dominio.Usuarios.Servicos.Interfaces
{
    public interface IUsuariosServico
    {
        void Inserir(UsuarioComando comando);
        Usuario Editar(int id, UsuarioComando comando);
        Usuario Instanciar(UsuarioComando comando);
        void Excluir(int id);
        Usuario Validar(int id);
        IList<Usuario> RecuperarUsuariosPorConversa(int idConversa);
        Usuario RecuperarUsuarioLogin(string nome, string senha);
    }
}