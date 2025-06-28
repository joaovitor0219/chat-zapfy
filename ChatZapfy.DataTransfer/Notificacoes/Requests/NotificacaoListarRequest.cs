using ChatZapfy.Dominio.Uteis;
using ChatZapfy.Dominio.Uteis.Enumeradores;

namespace ChatZapfy.DataTransfer.Notificacoes.Requests;

public class NotificacaoListarRequest : PaginacaoFiltro
{
    public NotificacaoListarRequest() : base(cpOrd: "", tpOrd: TipoOrdenacaoEnum.Asc) { }
}
