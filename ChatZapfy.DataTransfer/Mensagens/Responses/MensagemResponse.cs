using ChatZapfy.DataTransfer.Conversas.Responses;
using ChatZapfy.DataTransfer.Usuarios.Responses;

namespace ChatZapfy.DataTransfer.Mensagens.Responses.Responses;

public class MensagemResponse
{
    public ConversaResponse Conversa { get; set; }
    public UsuarioResponse Usuario{ get; set; }
    public string Conteudo { get; set; }
    public DateTime DataEnvio { get; set; }
}
