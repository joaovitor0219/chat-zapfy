namespace ChatZapfy.DataTransfer.Mensagens.Requests.Requests;

public class MensagemRequest
{
    public int IdConversa { get; protected set; }
    public int IdUsuario { get; protected set; }
    public string Conteudo { get; protected set; }
}
