using ChatZapfy.Dominio.Mensagens.Repositorios.Interfaces;
using ChatZapfy.Infra.Genericos;
using ChatZapfy.Dominio.Mensagens.Entidades;
using NHibernate;
using ChatZapfy.Dominio.Mensagens.Repositorios.Filtros;

namespace ChatZapfy.Infra.Mensagens.Repositorios;

public class MensagensRepositorio : GenericoRepositorio<Mensagem>, IMensagensRepositorio
{
    public MensagensRepositorio(ISession session) : base(session) { }

    public IQueryable<Mensagem> Filtrar(MensagemListarFiltro filtro)
        {
            var query = Query();

            if(filtro.Id.HasValue)
            {
                query = query.Where(x => x.Id == filtro.Id.Value);
            }
            
            if (filtro.IdUsuario.HasValue)
            {
            query = query.Where(x => x.Id == filtro.IdUsuario.Value);
            }
            
            if (filtro.IdConversa.HasValue)
            {
            query = query.Where(x => x.Id == filtro.IdConversa.Value);
            }

            if(!string.IsNullOrWhiteSpace(filtro.Conteudo))
            {
                query = query.Where(x => x.Conteudo.Trim().ToUpper().Contains(filtro.Conteudo.Trim().ToUpper()));
            }

            if(filtro.DataEnvio.HasValue)
            {
                query = query.Where(x => x.DataEnvio == filtro.DataEnvio.Value);
            }

            return query;
        }
}
