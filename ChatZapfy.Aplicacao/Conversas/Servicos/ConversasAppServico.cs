using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoglass.Autoplay.Aplicacao.Transacoes.Interfaces;
using AutoMapper;
using ChatZapfy.Aplicacao.Conversas.Servicos.Interfaces;
using ChatZapfy.DataTransfer.Conversas.Requests;
using ChatZapfy.DataTransfer.Conversas.Responses;
using ChatZapfy.Dominio.Conversas.Servicos.Interfaces;

namespace ChatZapfy.Aplicacao.Conversas.Servicos
{
    public class ConversasAppServico : IConversasAppServico
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IConversasServico conversasServico;

        public ConversasAppServico(IMapper mapper, IUnitOfWork unitOfWork, IConversasServico conversasServico)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.conversasServico = conversasServico;
        }

         public ConversaResponse Editar(int id, ConversaRequest request)
        {
            try
            {
                unitOfWork.BeginTransaction();

                var conversa = conversasServico.Editar(id,request.Nome);

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
    }
}