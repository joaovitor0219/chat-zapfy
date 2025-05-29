using Autoglass.Autoplay.Dominio.Util.Filtros;
using Autoglass.Autoplay.Dominio.Util.Filtros.Enumeradores;

namespace ChatZapfy.Dominio.Mensagens.Repositorios.Filtros;

public class MensagemListarFiltro : PaginacaoFiltro
{
    public int? Id { get; set; }
    public int? IdConversa { get; set; }
    public int? IdUsuario { get; set; }
    public string Conteudo { get; set; }
    public DateTime? DataEnvio { get; set; }

    public MensagemListarFiltro() : base(cpOrd: "Id", tpOrd: TipoOrdenacaoEnum.Asc) { }
}
