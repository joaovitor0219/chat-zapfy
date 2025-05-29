using ChatZapfy.Dominio.Conversas.Entidades;
using ChatZapfy.Dominio.Usuarios.Entidades;

namespace ChatZapfy.Dominio.Mensagens.Entidades;

public class Mensagem
{
    public virtual int Id { get; protected set; }
    public virtual int IdConversa { get; protected set; }
    public virtual int IdUsuario { get; protected set; }
    public virtual string Conteudo { get; protected set; }
    public virtual DateTime DataEnvio { get; protected set; }

    public virtual Usuario Usuario { get; protected set; }
    public virtual Conversa Conversa { get; protected set; }

    protected Mensagem() { }

    public Mensagem(int idConversa, int idUsuario, string conteudo)
    {
        SetIdConversa(idConversa);
        SetIdUsuario(idUsuario);
        SetConteudo(conteudo);
        SetDataEnvio(DateTime.Now);
    }

    public virtual void SetIdConversa(int idConversa)
    {
        IdConversa = idConversa;
    }

    public virtual void SetIdUsuario(int idUsuario)
    {
        IdUsuario = idUsuario;
    }

    public virtual void SetConteudo(string conteudo)
    {
        Conteudo = conteudo.Trim();
    }

    public virtual void SetDataEnvio(DateTime dataEnvio)
    {
        DataEnvio = dataEnvio;
    }

    public virtual void SetUsuario(Usuario usuario)
    {
        Usuario = usuario;
    }

    public virtual void SetConversa(Conversa conversa)
    {
        Conversa = conversa;
    }
}

