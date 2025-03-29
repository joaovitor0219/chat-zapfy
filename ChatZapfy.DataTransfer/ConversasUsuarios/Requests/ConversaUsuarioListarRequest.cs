using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoglass.Autoplay.Dominio.Util.Filtros;
using Autoglass.Autoplay.Dominio.Util.Filtros.Enumeradores;

namespace ChatZapfy.DataTransfer.ConversasUsuarios.Requests
{
    public class ConversaUsuarioListarRequest : PaginacaoFiltro
    {
         public int? Id { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdConversa { get; set; }
        public DateTime? DataInclusao { get; set; }

        public ConversaUsuarioListarRequest(): base(cpOrd: "Id", tpOrd:TipoOrdenacaoEnum.Asc)
        {}
    }
}