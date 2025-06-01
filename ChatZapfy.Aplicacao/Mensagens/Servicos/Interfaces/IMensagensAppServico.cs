using Autoglass.Autoplay.Dominio.Util;
using ChatZapfy.DataTransfer.Mensagens.Requests;
using ChatZapfy.DataTransfer.Mensagens.Requests.Requests;
using ChatZapfy.DataTransfer.Mensagens.Responses.Responses;

namespace ChatZapfy.Aplicacao.Mensagens.Servicos.Interfaces;

public interface IMensagensAppServico
{
    Task PublicarNaFilaAws(MensagemRequest request);
    MensagemResponse Recuperar(int id);
    PaginacaoConsulta<MensagemResponse> Listar(MensagemListarRequest request);
    Task InserirMensagens(string mensagemAws);
}
