using Autoglass.Autoplay.Dominio.Util.Filtros;
using Autoglass.Autoplay.Dominio.Util.Filtros.Enumeradores;

namespace ChatZapfy.Dominio.Mensagens.Repositorios.Filtros;

public class MensagemListarFiltro : PaginacaoFiltro
{
    public int? Id { get; set; }
    public int? IdConversa { get; protected set; }
    public int? IdUsuario { get; protected set; }
    public string Conteudo { get; protected set; }
    public DateTime? DataEnvio { get; protected set; }

    public MensagemListarFiltro() : base(cpOrd: "Id", tpOrd: TipoOrdenacaoEnum.Asc) { }
}
