using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoglass.Autoplay.Aplicacao.Transacoes.Interfaces;
using Autoglass.Autoplay.Dominio.Util;
using AutoMapper;
using ChatZapfy.Aplicacao.ConversasUsuarios.Servicos.Interfaces;
using ChatZapfy.DataTransfer.ConversasUsuarios.Requests;
using ChatZapfy.DataTransfer.ConversasUsuarios.Responses;
using ChatZapfy.Dominio.Conversas.Entidades;
using ChatZapfy.Dominio.Conversas.Servicos.Interfaces;
using ChatZapfy.Dominio.ConversasUsuarios.Entidades;
using ChatZapfy.Dominio.ConversasUsuarios.Repositorios;
using ChatZapfy.Dominio.ConversasUsuarios.Repositorios.Filtros;
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
        private readonly IConversasUsuariosRepositorio conversasUsuariosRepositorio;

        public ConversasUsuariosAppServico(IMapper mapper, IUnitOfWork unitOfWork, IConversasUsuariosServico conversasUsuariosServico, IUsuariosServico usuariosServico, IConversasServico conversasServico, IConversasUsuariosRepositorio conversasUsuariosRepositorio)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.conversasUsuariosServico = conversasUsuariosServico;
            this.usuariosServico = usuariosServico;
            this.conversasServico = conversasServico;
            this.conversasUsuariosRepositorio = conversasUsuariosRepositorio;
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

        public PaginacaoConsulta<ConversaUsuarioResponse> Listar(ConversaUsuarioListarRequest request)
        {
            ConversaUsuarioListarFiltro filtro = mapper.Map<ConversaUsuarioListarFiltro>(request);

            IQueryable<ConversaUsuario> query = conversasUsuariosRepositorio.Filtrar(filtro);

            PaginacaoConsulta<ConversaUsuario> conversasUsuarios = conversasUsuariosRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.TpOrd);

            return mapper.Map<PaginacaoConsulta<ConversaUsuarioResponse>>(conversasUsuarios);
        }
    }
}