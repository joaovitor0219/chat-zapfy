using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoglass.Autoplay.Aplicacao.Transacoes.Interfaces;
using AutoMapper;
using ChatZapfy.Aplicacao.ConversasUsuarios.Servicos.Interfaces;
using ChatZapfy.DataTransfer.ConversasUsuarios.Requests;
using ChatZapfy.DataTransfer.ConversasUsuarios.Responses;
using ChatZapfy.Dominio.Conversas.Entidades;
using ChatZapfy.Dominio.Conversas.Servicos.Interfaces;
using ChatZapfy.Dominio.ConversasUsuarios.Servicos.Interfaces;
using ChatZapfy.Dominio.Usuarios.Entidades;
using ChatZapfy.Dominio.Usuarios.Servicos.Interfaces;

namespace ChatZapfy.Aplicacao.ConversasUsuarios.Servicos
{
    public class ConversasUsuariosAppServico : IConversasUsuariosAppServico
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IConversasUsuariosServico conversasUsuariosServico;
        private readonly IUsuariosServico usuariosServico;
        private readonly IConversasServico conversasServico;

        public ConversasUsuariosAppServico(IMapper mapper, IUnitOfWork unitOfWork, IConversasUsuariosServico conversasUsuariosServico, IUsuariosServico usuariosServico, IConversasServico conversasServico)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.conversasUsuariosServico = conversasUsuariosServico;
            this.usuariosServico = usuariosServico;
            this.conversasServico = conversasServico;
        }

        public void Excluir(int id)
        {
            try
            {
                unitOfWork.BeginTransaction();

                conversasUsuariosServico.Excluir(id);

                unitOfWork.Commit();
            }
            catch
            {
                unitOfWork.Rollback();

                throw;
            }
        }

        public void Inserir(ConversaUsuarioRequest request)
        {
            try
            {
                unitOfWork.BeginTransaction();

                Usuario usuario = usuariosServico.Validar(request.IdUsuario);

                Conversa conversa = conversasServico.Validar(request.IdConversa);

                conversasUsuariosServico.Inserir(usuario, conversa);

                unitOfWork.Commit();
            }
            catch
            {
                unitOfWork.Rollback();

                throw;
            }
        }

        public ConversaUsuarioResponse Recuperar(int id)
        {
            var conversaUsuariio = conversasUsuariosServico.Validar(id);

            return mapper.Map<ConversaUsuarioResponse>(conversaUsuariio);
        }
    }
}