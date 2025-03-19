using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatZapfy.Aplicacao.Usuarios.Servicos.Interfaces;
using ChatZapfy.DataTransfer.Usuarios.Requests;
using ChatZapfy.DataTransfer.Usuarios.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ChatZapfy.API.Usuarios
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosAppServico usuariosAppServico;

        public UsuariosController(IUsuariosAppServico usuariosAppServico)
        {
            this.usuariosAppServico = usuariosAppServico;
        }


        /// <summary>
        /// Recupera um usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<UsuarioResponse> Recuperar(int id)
        {
            UsuarioResponse response = usuariosAppServico.Recuperar(id);

            return Ok(response);
        }


        /// <summary>
        /// Adiciona um novo usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<UsuarioResponse> Inserir([FromBody] UsuarioRequest request)
        {
            usuariosAppServico.Inserir(request);

            return Ok();
        }

        /// <summary>
        /// Edita um usuário por Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult<UsuarioResponse> Editar(int id, [FromBody] UsuarioRequest request)
        {
            UsuarioResponse response = usuariosAppServico.Editar(id, request);

            return Ok(response);
        }

        /// <summary>
        /// Exclui um usuário por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Excluir(int id)
        {
            usuariosAppServico.Excluir(id);

            return Ok();
        }
    }
}