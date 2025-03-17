using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplicativoTarefa.Dominio.Execoes;
using ChatZapfy.Dominio.Conversas.Entidades;
using ChatZapfy.Dominio.Conversas.Repositorios;
using ChatZapfy.Dominio.Conversas.Servicos.Interfaces;

namespace ChatZapfy.Dominio.Conversas.Servicos
{
    public class ConversasServico : IConversasServico
    {
        private readonly IConversasRepositorio conversasRepositorio;

        public ConversasServico(IConversasRepositorio conversasRepositorio)
        {
            this.conversasRepositorio = conversasRepositorio;
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

            if(conversa is null)
                throw new RegraDeNegocioExcecao("Conversa é obrigatório");

            return conversa;
        }
    }
}