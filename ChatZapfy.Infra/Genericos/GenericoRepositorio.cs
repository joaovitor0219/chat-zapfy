using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoglass.Autoplay.Dominio.Util;
using Autoglass.Autoplay.Dominio.Util.Filtros.Enumeradores;
using ChatZapfy.Dominio.Genericos.Interfaces;
using NHibernate;
using System.Linq.Dynamic.Core;

namespace ChatZapfy.Infra.Genericos
{
    public class GenericoRepositorio<T> : IGenericoRepositorio<T> where T : class
    {
        private readonly ISession session;

        public GenericoRepositorio(ISession session)
        {
            this.session = session;
        }

        public T Editar(T entidade)
        {
            session.Update(entidade);
            return entidade;
        }

        public void Excluir(T entidade)
        {
            session.Delete(entidade);
        }

        public T Inserir(T entidade)
        {
            session.Save(entidade);
            return entidade;
        }

        public PaginacaoConsulta<T> Listar(IQueryable<T> query, int qt, int pg, string cpOrd, TipoOrdenacaoEnum tpOrd)
        {
            try
            {
                query = query.OrderBy(cpOrd + " " + tpOrd.ToString());
                return Paginar(query, qt, pg);
            }
            catch
            {
                throw new ArgumentException("Campo da ordenação não informado");
            }
        }

        private static PaginacaoConsulta<T> Paginar(IQueryable<T> query, int qt, int pg)
        {
            return new PaginacaoConsulta<T>
            {
                Registros = query.Skip((pg - 1) * qt).Take(qt).ToList(),
                Total = query.LongCount(),
            };
        }

        public IQueryable<T> Query()
        {
            return session.Query<T>();
        }

        public T Recuperar(int id)
        {
            return session.Get<T>(id);
        }

        public void Inserir(IEnumerable<T> entidades)
        {
            foreach (T entidade in entidades)
            {
                session.Save(entidade);
            }
        }

        public async Task InserirAsync(T entidade)
        {
            await session.SaveAsync(entidade);
        }

        public Task InserirVariasAsync(IEnumerable<T> entidades)
        {
            foreach (T entidade in entidades)
            {
                session.Save(entidade);
            }

            return Task.CompletedTask;
        }
    }
}