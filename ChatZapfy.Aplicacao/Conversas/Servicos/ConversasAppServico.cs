using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoglass.Autoplay.Aplicacao.Transacoes.Interfaces;
using Autoglass.Autoplay.Dominio.Util;
using AutoMapper;
using ChatZapfy.Aplicacao.Conversas.Servicos.Interfaces;
using ChatZapfy.DataTransfer.Conversas.Requests;
using ChatZapfy.DataTransfer.Conversas.Responses;
using ChatZapfy.Dominio.Conversas.Entidades;
using ChatZapfy.Dominio.Conversas.Repositorios;
using ChatZapfy.Dominio.Conversas.Repositorios.Filtros;
using ChatZapfy.Dominio.Conversas.Servicos.Interfaces;

namespace ChatZapfy.Aplicacao.Conversas.Servicos
{
    public class ConversasAppServico : IConversasAppServico
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IConversasServico conversasServico;
        private readonly IConversasRepositorio conversasRepositorio;

        public ConversasAppServico(IMapper mapper, IUnitOfWork unitOfWork, IConversasServico conversasServico, IConversasRepositorio conversasRepositorio)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.conversasServico = conversasServico;
            this.conversasRepositorio = conversasRepositorio;
        }

        public ConversaResponse Editar(int id, ConversaRequest request)
        {
            try
            {
                unitOfWork.BeginTransaction();

                var conversa = conversasServico.Editar(id, request.Nome);

                unitOfWork.Commit();

                return mapper.Map<ConversaResponse>(conversa);
            }
            catch
            {
                unitOfWork.Rollback();

                throw;
            }
        }

        public void Excluir(int id)
        {
            try
            {
                unitOfWork.BeginTransaction();

                conversasServico.Excluir(id);

                unitOfWork.Commit();
            }
            catch
            {
                unitOfWork.Rollback();

                throw;
            }
        }

        public void Inserir(ConversaRequest request)
        {
            try
            {
                unitOfWork.BeginTransaction();

                conversasServico.Inserir(request.Grupo, request.Nome);

                unitOfWork.Commit();
            }
            catch
            {
                unitOfWork.Rollback();

                throw;
            }

        }

        public ConversaResponse Recuperar(int id)
        {
            var conversa = conversasServico.Validar(id);

            return mapper.Map<ConversaResponse>(conversa);
        }

        public PaginacaoConsulta<ConversaResponse> Listar(ConversasListarRequest request)
        {
            ConversaListarFiltro filtro = mapper.Map<ConversaListarFiltro>(request);

            IQueryable<Conversa> query = conversasRepositorio.Filtrar(filtro);

            PaginacaoConsulta<Conversa> conversas = conversasRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.TpOrd);

            return mapper.Map<PaginacaoConsulta<ConversaResponse>>(conversas);
        }
        
        public IList<ConversaResponse> ListarConversasPorUsuario(ConversaPorUsuarioListarRequest request)
        {
            IList<Conversa> conversas = conversasServico.RecuperarConversasPorUsuario(request.IdUsuario);

            return mapper.Map<List<ConversaResponse>>(conversas);
        }
    }
}