using AplicativoTarefa.Dominio.Execoes;
using ChatZapfy.Dominio.Conversas.Entidades;
using ChatZapfy.Dominio.Conversas.Servicos.Interfaces;
using ChatZapfy.Dominio.Mensagens.Entidades;
using ChatZapfy.Dominio.Mensagens.Repositorios.Interfaces;
using ChatZapfy.Dominio.Mensagens.Servicos.Comandos;
using ChatZapfy.Dominio.Mensagens.Servicos.Interfaces;
using ChatZapfy.Dominio.Usuarios.Entidades;
using ChatZapfy.Dominio.Usuarios.Servicos.Interfaces;

namespace ChatZapfy.Dominio.Mensagens.Servicos;

public class MensagensServico : IMensagensServico
{
    private readonly IMensagensRepositorio mensagensRepositorio;
    private readonly IUsuariosServico usuariosServico;
    private readonly IConversasServico conversasServico;

    public MensagensServico(
        IMensagensRepositorio mensagensRepositorio,
        IUsuariosServico usuariosServico,
        IConversasServico conversasServico)
    {
        this.mensagensRepositorio = mensagensRepositorio;
        this.usuariosServico = usuariosServico;
        this.conversasServico = conversasServico;
    }

    public async Task Inserir(MensagemComando comando)
    {
        if (comando.IdUsuario == 0 && comando.IdConversa == 0 && string.IsNullOrWhiteSpace(comando.Conteudo))
        {
            throw new RegraDeNegocioExcecao("Mensagem não enviada corretamente");
        }

        Mensagem mensagem = Instanciar(comando.IdConversa, comando.IdUsuario, comando.Conteudo);

        await mensagensRepositorio.InserirAsync(mensagem);
    }

    public Mensagem Instanciar(int idConversa, int idUsuario, string conteudo)
    {
        Conversa conversa = conversasServico.Validar(idConversa);

        Usuario usuario = usuariosServico.Validar(idUsuario);

        Mensagem mensagem = new Mensagem(conversa, usuario, conteudo);

        return mensagem;
    }

    public Mensagem Validar(int id)
    {
        Mensagem mensagem = mensagensRepositorio.Recuperar(id);

        if (mensagem is null)
            throw new RegraDeNegocioExcecao("Mensagem não foi encontrada");

        return mensagem;
    }
}
