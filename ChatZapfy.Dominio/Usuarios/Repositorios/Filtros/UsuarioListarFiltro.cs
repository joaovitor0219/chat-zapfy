using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoglass.Autoplay.Dominio.Util.Filtros;
using Autoglass.Autoplay.Dominio.Util.Filtros.Enumeradores;

namespace ChatZapfy.Dominio.Usuarios.Repositorios.Filtros
{
    public class UsuarioListarFiltro : PaginacaoFiltro
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime? DataInclusao { get; set; }

        public UsuarioListarFiltro(): base(cpOrd: "Id", tpOrd:TipoOrdenacaoEnum.Asc)
        {}
    }
}