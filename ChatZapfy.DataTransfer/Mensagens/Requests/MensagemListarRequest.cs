using Autoglass.Autoplay.Dominio.Util.Filtros;
using Autoglass.Autoplay.Dominio.Util.Filtros.Enumeradores;

namespace ChatZapfy.DataTransfer.Mensagens.Requests;

public class MensagemListarRequest : PaginacaoFiltro
{
    public int? Id { get; set; }
    public int? IdConversa { get; set; }
    public int? IdUsuario { get; set; }
    public string Conteudo { get; set; }
    public DateTime? DataEnvio { get; set; }
    public MensagemListarRequest() : base(cpOrd: "Id", tpOrd: TipoOrdenacaoEnum.Asc) { }
}
