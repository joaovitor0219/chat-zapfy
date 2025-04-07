using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoglass.Autoplay.Dominio.Util;
using ChatZapfy.Aplicacao.ConversasUsuarios.Servicos.Interfaces;
using ChatZapfy.DataTransfer.ConversasUsuarios.Requests;
using ChatZapfy.DataTransfer.ConversasUsuarios.Responses;
using ChatZapfy.Dominio.ConversasUsuarios.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChatZapfy.API.ConversasUsuarios
{
    [ApiController]
    [Route("api/conversas-usuarios")]
    public class ConversasUsuariosController : ControllerBase
    {
        private readonly IConversasUsuariosAppServico conversasUsuariosAppServico;

        public ConversasUsuariosController(IConversasUsuariosAppServico conversasUsuariosAppServico)
        {
            this.conversasUsuariosAppServico = conversasUsuariosAppServico;
        }

        /// <summary>
        /// Recupera uma conversa usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<ConversaUsuarioResponse> Recuperar(int id)
        {
            ConversaUsuarioResponse response = conversasUsuariosAppServico.Recuperar(id);

            return Ok(response);
        }


        /// <summary>
        /// Adiciona uma nova conversa usuario
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<ConversaUsuarioResponse> Inserir([FromBody] ConversaUsuarioRequest request)
        {
            conversasUsuariosAppServico.Inserir(request);

            return Ok();
        }


        /// <summary>
        /// Exclui uma conversa usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Excluir(int id)
        {
            conversasUsuariosAppServico.Excluir(id);

            return Ok();
        }

        /// <summary>
        /// Recupera a lista de conversas usuarios paginado
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<PaginacaoConsulta<ConversaUsuarioResponse>> Listar([FromQuery]ConversaUsuarioListarRequest request)
        {
            var response = conversasUsuariosAppServico.Listar(request);

            return Ok(response);
        }
    }
}