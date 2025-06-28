using ChatZapfy.Dominio.Conversas.Entidades;
using ChatZapfy.Dominio.Mensagens.Entidades;
using ChatZapfy.Dominio.Usuarios.Entidades;

namespace ChatZapfy.Dominio.Notificacoes.Entidades;

public class Notificacao
{
    public virtual int Id { get; protected set; }
    public virtual Usuario Usuario { get; protected set; }
    public virtual Mensagem Mensagem { get; protected set; }
    public virtual Conversa Conversa { get; protected set; }
    public virtual bool Visualizada { get; protected set; }
    public virtual DateTime DataCriacao { get; protected set; }

    public Notificacao() { }

    public Notificacao(Usuario usuario, Mensagem mensagem, Conversa conversa, bool visualizada)
    {
        SetUsuario(usuario);
        SetConversa(conversa);
        SetMensagem(mensagem);
        SetVisualizada(visualizada);
        DataCriacao = DateTime.Now;
    }

    public virtual void SetUsuario(Usuario usuario)
    {
        Usuario = usuario;
    }
    public virtual void SetConversa(Conversa conversa)
    {
        Conversa = conversa;
    }
    public virtual void SetMensagem(Mensagem mensagem)
    {
        Mensagem = mensagem;
    }
    public virtual void SetVisualizada(bool visualizada)
    {
        Visualizada = visualizada;
    }
}
