using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ChatZapfy.DataTransfer.Usuarios.Requests;
using ChatZapfy.DataTransfer.Usuarios.Responses;
using ChatZapfy.Dominio.Usuarios.Entidades;
using ChatZapfy.Dominio.Usuarios.Servicos.Comandos;

namespace ChatZapfy.Aplicacao.Usuarios.Profiles
{
    public class UsuariosProfile : Profile
    {
        public UsuariosProfile()
        {
            CreateMap<Usuario, UsuarioResponse>();
            CreateMap<UsuarioRequest, UsuarioComando>();
        }
    }
}