using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoglass.Autoplay.Dominio.Util;
using ChatZapfy.DataTransfer.Usuarios.Requests;
using ChatZapfy.DataTransfer.Usuarios.Responses;

namespace ChatZapfy.Aplicacao.Usuarios.Servicos.Interfaces
{
    public interface IUsuariosAppServico
    {
        void Inserir(UsuarioRequest request);
        UsuarioResponse Recuperar(int id);
        void Excluir(int id);
        UsuarioResponse Editar(int id, UsuarioRequest request);
        PaginacaoConsulta<UsuarioResponse> Listar(UsuarioListarRequest request);
        IList<UsuarioResponse> ListarUsuariosPorConversa(UsuarioPorConversaListarRequest request);
        UsuarioResponse RecuperarUsuarioLogin(UsuarioLoginRequest request);
    }
}