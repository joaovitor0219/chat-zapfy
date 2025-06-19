using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplicativoTarefa.Dominio.Execoes;
using ChatZapfy.Dominio.Conversas.Entidades;
using ChatZapfy.Dominio.Conversas.Repositorios;
using ChatZapfy.Dominio.Conversas.Servicos.Interfaces;
using ChatZapfy.Dominio.ConversasUsuarios.Entidades;
using ChatZapfy.Dominio.ConversasUsuarios.Servicos.Interfaces;

namespace ChatZapfy.Dominio.Conversas.Servicos
{
    public class ConversasServico : IConversasServico
    {
        private readonly IConversasRepositorio conversasRepositorio;
        private readonly IConversasUsuariosServico conversasUsuariosServico;

        public ConversasServico(IConversasRepositorio conversasRepositorio, IConversasUsuariosServico conversasUsuariosServico)
        {
            this.conversasRepositorio = conversasRepositorio;
            this.conversasUsuariosServico = conversasUsuariosServico;
        }

        public Conversa Editar(int id, string nome)
        {
            Conversa conversa = Validar(id);

            conversa.SetNome(nome);

            conversasRepositorio.Editar(conversa);

            return conversa;
        }

        public void Excluir(int id)
        {
            Conversa conversa = Validar(id);

            conversasRepositorio.Excluir(conversa);
        }

        public void Inserir(bool grupo, string nome)
        {
            Conversa conversa = Instanciar(grupo, nome);

            conversasRepositorio.Inserir(conversa);
        }

        public Conversa Instanciar(bool grupo, string nome)
        {
            return new Conversa(grupo, nome);
        }

        public Conversa Validar(int id)
        {
            Conversa conversa = conversasRepositorio.Recuperar(id);

            if (conversa is null)
                throw new RegraDeNegocioExcecao("Conversa não encontrada");

            return conversa;
        }
        
        public IList<Conversa> RecuperarConversasPorUsuario(int idUsuario)
        {
            IList<ConversaUsuario> conversaUsuarios = conversasUsuariosServico.RecuperarConversaUsuarioPorUsuario(idUsuario);

            IList<Conversa> conversas = new List<Conversa>();

            foreach (var conversaUsuario in conversaUsuarios)
            {
                Conversa conversa = Validar(conversaUsuario.Conversa.Id);

                conversas.Add(conversa);
            }

            return conversas;
        }
    }
}