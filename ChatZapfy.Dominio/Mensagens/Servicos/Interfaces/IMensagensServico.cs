using System.Runtime.CompilerServices;
using ChatZapfy.Dominio.Mensagens.Entidades;

namespace ChatZapfy.Dominio.Mensagens.Servicos.Interfaces;

public interface IMensagensServico
{
    void Inserir(int idConversa, int idUsuario, string conteudo);
    Mensagem Instanciar(int idConversa, int idUsuario, string conteudo);
    Mensagem Validar(int id);
}
