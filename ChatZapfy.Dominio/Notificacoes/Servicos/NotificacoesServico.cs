using ChatZapfy.Dominio.Conversas.Entidades;
using ChatZapfy.Dominio.Conversas.Servicos.Interfaces;
using ChatZapfy.Dominio.ConversasUsuarios.Entidades;
using ChatZapfy.Dominio.ConversasUsuarios.Repositorios;
using ChatZapfy.Dominio.ConversasUsuarios.Servicos.Interfaces;
using ChatZapfy.Dominio.Mensagens.Entidades;
using ChatZapfy.Dominio.Mensagens.Servicos.Interfaces;
using ChatZapfy.Dominio.Notificacoes.Entidades;
using ChatZapfy.Dominio.Notificacoes.Repositorios.Interfaces;
using ChatZapfy.Dominio.Notificacoes.Servicos.Comandos;
using ChatZapfy.Dominio.Notificacoes.Servicos.Interfaces;
using ChatZapfy.Dominio.Usuarios.Entidades;
using ChatZapfy.Dominio.Usuarios.Repositorios.Interfaces;
using ChatZapfy.Dominio.Usuarios.Servicos.Interfaces;

namespace ChatZapfy.Dominio.Notificacoes.Servicos;

public class NotificacoesServico : INotificacoesServico
{
    private readonly INotificacoesRepositorio notificacoesRepositorio;
    private readonly IConversasUsuariosServico conversasUsuariosServico;
    private readonly IConversasServico conversasServico;
    private readonly IMensagensServico mensagensServico;
    private readonly IUsuariosServico usuariosServico;

    public NotificacoesServico(INotificacoesRepositorio notificacoesRepositorio, IConversasUsuariosServico conversasUsuariosServico, IConversasServico conversasServico, IMensagensServico mensagensServico, IUsuariosServico usuariosServico)
    {
        this.notificacoesRepositorio = notificacoesRepositorio;
        this.conversasUsuariosServico = conversasUsuariosServico;
        this.conversasServico = conversasServico;
        this.mensagensServico = mensagensServico;
        this.usuariosServico = usuariosServico;
    }

    public Notificacao Instanciar(NotificacaoComando comando)
    {
        Conversa conversa = conversasServico.Validar(comando.IdConversa);

        Usuario usuario = usuariosServico.Validar(comando.IdUsuario);

        Notificacao notificacao = new Notificacao(usuario, conversa, false);

        return notificacao;
    }

    public async Task CriarNotificaoAsync(NotificacaoComando comando)
    {
        Conversa conversa = conversasServico.Validar(comando.IdConversa);

        IList<ConversaUsuario> usuariosNaConversa = conversasUsuariosServico.RecuperarConversaUsuarioPorConversa(comando.IdConversa);

        IList<ConversaUsuario> usuariosParaNotificar = usuariosNaConversa.Where(x => x.Usuario.Id != comando.IdUsuario).ToList();

        List<Notificacao> notificacoes = new List<Notificacao>();

        foreach (var conversaUsuario in usuariosParaNotificar)
        {
            Notificacao notificacao = new Notificacao(conversaUsuario.Usuario, conversa, comando.Visualizada);

            notificacoes.Add(notificacao);
        }

        await notificacoesRepositorio.InserirVariasAsync(notificacoes);
    }

    public Task InserirAsync(NotificacaoComando comando)
    {
        throw new NotImplementedException();
    }
}
