using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoglass.Autoplay.Dominio.Util.Filtros;
using Autoglass.Autoplay.Dominio.Util.Filtros.Enumeradores;

namespace ChatZapfy.DataTransfer.Conversas.Requests
{
    public class ConversasListarRequest : PaginacaoFiltro
    {
         public int? Id { get; set; }
        public bool? Grupo { get; set; }
        public string Nome { get; set; }
        public DateTime? DataInclusao { get; set; }

        public ConversasListarRequest(): base(cpOrd: "Id", tpOrd:TipoOrdenacaoEnum.Asc)
        {}
    }
}