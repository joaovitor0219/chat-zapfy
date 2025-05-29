using Autoglass.Autoplay.Dominio.Util;
using ChatZapfy.Aplicacao.Mensagens.Servicos.Interfaces;
using ChatZapfy.DataTransfer.Mensagens.Requests;
using ChatZapfy.DataTransfer.Mensagens.Requests.Requests;
using ChatZapfy.DataTransfer.Mensagens.Responses.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ChatZapfy.API.Controllers.Mensagens;

[Route("api/mensagens")]
[ApiController]
public class MensagensController : ControllerBase
{
    private readonly IMensagensAppServico mensagensAppServico;

    public MensagensController(IMensagensAppServico mensagensAppServico)
    {
        this.mensagensAppServico = mensagensAppServico;
    }

    /// <summary>
    /// Recupera uma mensagem
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<MensagemResponse> Recuperar(int id)
    {
        MensagemResponse response = mensagensAppServico.Recuperar(id);

        return Ok(response);
    }

    /// <summary>
    /// Recupera a lista de mensagens paginado
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<PaginacaoConsulta<MensagemResponse>> Listar([FromQuery] MensagemListarRequest request)
    {
        var response = mensagensAppServico.Listar(request);

        return Ok(response);
    }


    /// <summary>
    /// Adiciona uma nova mensagem
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult<MensagemResponse> Inserir([FromBody] MensagemRequest request)
    {
        mensagensAppServico.Inserir(request);

        return Ok();
    }
}
