using ChatZapfy.Dominio.Genericos.Interfaces;
using ChatZapfy.Dominio.Mensagens.Entidades;
using ChatZapfy.Dominio.Mensagens.Repositorios.Filtros;

namespace ChatZapfy.Dominio.Mensagens.Repositorios.Interfaces;

public interface IMensagensRepositorio : IGenericoRepositorio<Mensagem>
{
    IQueryable<Mensagem> Filtrar(MensagemListarFiltro filtro);
    IQueryable<Mensagem> ListarMensagemPorConversa(int idConversa);
}
