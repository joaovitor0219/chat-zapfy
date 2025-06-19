using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoglass.Autoplay.Dominio.Util;
using ChatZapfy.Aplicacao.Conversas.Servicos.Interfaces;
using ChatZapfy.DataTransfer.Conversas.Requests;
using ChatZapfy.DataTransfer.Conversas.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ChatZapfy.API.Conversas
{
    [ApiController]
    [Route("api/conversas")]
    public class ConversasController : ControllerBase
    {
        private readonly IConversasAppServico conversasAppServico;

        public ConversasController(IConversasAppServico conversasAppServico)
        {
            this.conversasAppServico = conversasAppServico;
        }

        /// <summary>
        /// Recupera uma conversa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<ConversaResponse> Recuperar(int id)
        {
            ConversaResponse response = conversasAppServico.Recuperar(id);

            return Ok(response);
        }

        /// <summary>
        /// Recupera a lista de conversas paginado
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<PaginacaoConsulta<ConversaResponse>> Listar([FromQuery]ConversasListarRequest request)
        {
            var response = conversasAppServico.Listar(request);

            return Ok(response);
        }

        /// <summary>
        /// Recupera uma lista de conversas por usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("conversas-usuarios")]
        public ActionResult<PaginacaoConsulta<ConversaResponse>> ListarConversasPorUsuario([FromQuery]ConversaPorUsuarioListarRequest request)
        {
            var response = conversasAppServico.ListarConversasPorUsuario(request);

            return Ok(response);
        }


        /// <summary>
        /// Adiciona uma nova conversa
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<ConversaResponse> Inserir([FromBody] ConversaRequest request)
        {
            conversasAppServico.Inserir(request);

            return Ok();
        }

        /// <summary>
        /// Edita uma conversa por id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult<ConversaResponse> Editar(int id, [FromBody] ConversaRequest request)
        {
            ConversaResponse response = conversasAppServico.Editar(id, request);

            return Ok(response);
        }

        /// <summary>
        /// Exclui uma conversa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Excluir(int id)
        {
            conversasAppServico.Excluir(id);

            return Ok();
        }
    }
}