using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoglass.Autoplay.Dominio.Util;
using Autoglass.Autoplay.Dominio.Util.Filtros.Enumeradores;

namespace ChatZapfy.Dominio.Genericos.Interfaces
{
    public interface IGenericoRepositorio<T> where T : class
    {
        T Recuperar(int id);
        T Inserir(T entidade);
        T Editar(T entidade);
        void Excluir(T entidade);
        PaginacaoConsulta<T> Listar(IQueryable<T> query, int qt, int pg, string cpOrd, TipoOrdenacaoEnum tpOrd);
        IQueryable<T> Query();
        void Inserir(IEnumerable<T> entidades);
    }
}