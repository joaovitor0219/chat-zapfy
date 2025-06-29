namespace ChatZapfy.DataTransfer.Notificacoes.Requests.Requests;

public class NotificacaoRequest
{
    public int IdUsuario { get; set; }
    public int IdConversa { get; set; }
    public bool Visualizada { get; set; }
}
