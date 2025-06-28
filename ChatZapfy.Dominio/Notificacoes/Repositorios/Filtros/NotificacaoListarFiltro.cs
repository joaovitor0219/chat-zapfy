using ChatZapfy.Dominio.Uteis;
using ChatZapfy.Dominio.Uteis.Enumeradores;

namespace ChatZapfy.Dominio.Notificacoes.Repositorios.Filtros;

public class NotificacaoListarFiltro : PaginacaoFiltro
{
    public NotificacaoListarFiltro() : base(cpOrd: "", tpOrd: TipoOrdenacaoEnum.Asc) { }
}
