using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoglass.Autoplay.Dominio.Util.Filtros;
using Autoglass.Autoplay.Dominio.Util.Filtros.Enumeradores;

namespace ChatZapfy.Dominio.Conversas.Repositorios.Filtros
{
    public class ConversaListarFiltro : PaginacaoFiltro
    {
        public int? Id { get; set; }
        public bool? Grupo { get; set; }
        public string Nome { get; set; }
        public DateTime? DataInclusao { get; set; }

        public ConversaListarFiltro(): base(cpOrd: "Id", tpOrd:TipoOrdenacaoEnum.Asc)
        {}
    }
}