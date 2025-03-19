using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Antlr.Runtime.Tree;
using Autoglass.Autoplay.Aplicacao.Transacoes.Interfaces;
using AutoMapper;
using ChatZapfy.Aplicacao.Usuarios.Servicos.Interfaces;
using ChatZapfy.DataTransfer.Usuarios.Requests;
using ChatZapfy.DataTransfer.Usuarios.Responses;
using ChatZapfy.Dominio.Usuarios.Servicos;
using ChatZapfy.Dominio.Usuarios.Servicos.Comandos;
using ChatZapfy.Dominio.Usuarios.Servicos.Interfaces;

namespace ChatZapfy.Aplicacao.Usuarios.Servicos
{
    public class UsuariosAppServico : IUsuariosAppServico
    {
        private readonly IUsuariosServico usuariosServico;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public UsuariosAppServico(IUsuariosServico usuariosServico, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.usuariosServico = usuariosServico;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public UsuarioResponse Editar(int id, UsuarioRequest request)
        {
            var comando = mapper.Map<UsuarioComando>(request); 

            try
            {
                unitOfWork.BeginTransaction();

                var usuario = usuariosServico.Editar(id,comando);

                unitOfWork.Commit();

                return mapper.Map<UsuarioResponse>(usuario);
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

                usuariosServico.Excluir(id);

                unitOfWork.Commit();
            }
            catch
            {
                unitOfWork.Rollback();

                throw;
            }
        }

        public void Inserir(UsuarioRequest request)
        {
            var comando = mapper.Map<UsuarioComando>(request);

            try
            {
                unitOfWork.BeginTransaction();

                usuariosServico.Inserir(comando);

                unitOfWork.Commit();
            }
            catch
            {
                unitOfWork.Rollback();

                throw;
            }

        }

        public UsuarioResponse Recuperar(int id)
        {
            var usuario = usuariosServico.Validar(id);

            return mapper.Map<UsuarioResponse>(usuario);
        }
    }
}