namespace ChatZapfy.Dominio.Mensagens.Servicos.Comandos;

public class MensagemComando
{
    public int IdConversa { get; protected set; }
    public int IdUsuario { get; protected set; }
    public string Conteudo { get; protected set; }
    public DateTime DataEnvio { get; protected set; }
}
