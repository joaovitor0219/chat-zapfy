namespace ChatZapfy.DataTransfer.Mensagens.Responses.Responses;

public class MensagemResponse
{
    public int IdConversa { get; set; }
    public int IdUsuario { get; set; }
    public string Conteudo { get; set; }
    public DateTime DataEnvio { get; set; }
}
