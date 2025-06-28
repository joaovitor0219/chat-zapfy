using Autoglass.Autoplay.Dominio.Util.Filtros;
using Autoglass.Autoplay.Dominio.Util.Filtros.Enumeradores;

namespace ChatZapfy.Dominio.Notificacoes.Repositorios.Filtros;

public class NotificacaoListarFiltro : PaginacaoFiltro
{
    public NotificacaoListarFiltro() : base(cpOrd: "", tpOrd: TipoOrdenacaoEnum.Asc) { }
}
