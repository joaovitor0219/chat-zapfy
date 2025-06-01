namespace ChatZapfy.Dominio.Mensagens.Servicos.Comandos;

public class MensagemComando
{
    public int IdConversa { get; set; }
    public int IdUsuario { get; set; }
    public string Conteudo { get; set; }
    public DateTime DataEnvio { get; set; }
}
