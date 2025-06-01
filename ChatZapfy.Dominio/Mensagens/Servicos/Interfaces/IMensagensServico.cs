using System.Runtime.CompilerServices;
using ChatZapfy.Dominio.Mensagens.Entidades;
using ChatZapfy.Dominio.Mensagens.Servicos.Comandos;

namespace ChatZapfy.Dominio.Mensagens.Servicos.Interfaces;

public interface IMensagensServico
{
    Task Inserir(MensagemComando comando);
    Mensagem Instanciar(int idConversa, int idUsuario, string conteudo);
    Mensagem Validar(int id);
}
