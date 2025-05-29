using AplicativoTarefa.Dominio.Execoes;
using ChatZapfy.Dominio.Mensagens.Entidades;
using ChatZapfy.Dominio.Mensagens.Repositorios.Interfaces;
using ChatZapfy.Dominio.Mensagens.Servicos.Interfaces;

namespace ChatZapfy.Dominio.Mensagens.Servicos;

public class MensagensServico : IMensagensServico
{
    private readonly IMensagensRepositorio mensagensRepositorio;

    public MensagensServico(IMensagensRepositorio mensagensRepositorio)
    {
        this.mensagensRepositorio = mensagensRepositorio;
    }

    public void Inserir(int idConversa, int idUsuario, string conteudo)
    {
        Mensagem mensagem = Instanciar(idConversa, idUsuario, conteudo);

        mensagensRepositorio.Inserir(mensagem);
    }

    public Mensagem Instanciar(int idConversa, int idUsuario, string conteudo)
    {
        Mensagem mensagem = new Mensagem(idConversa, idUsuario, conteudo);

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
