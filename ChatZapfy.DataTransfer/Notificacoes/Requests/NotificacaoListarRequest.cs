using Autoglass.Autoplay.Dominio.Util.Filtros;
using Autoglass.Autoplay.Dominio.Util.Filtros.Enumeradores;

namespace ChatZapfy.DataTransfer.Notificacoes.Requests;

public class NotificacaoListarRequest : PaginacaoFiltro
{
    public NotificacaoListarRequest() : base(cpOrd: "", tpOrd: TipoOrdenacaoEnum.Asc) { }
}
