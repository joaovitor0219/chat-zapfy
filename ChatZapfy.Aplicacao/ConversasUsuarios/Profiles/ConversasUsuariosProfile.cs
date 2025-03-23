using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ChatZapfy.DataTransfer.ConversasUsuarios.Responses;
using ChatZapfy.Dominio.ConversasUsuarios.Entidades;

namespace ChatZapfy.Aplicacao.ConversasUsuarios.Profiles
{
    public class ConversasUsuariosProfile : Profile
    {
        public ConversasUsuariosProfile()
        {
            CreateMap<ConversaUsuario, ConversaUsuarioResponse>()
            .ForMember(x => x.Conversa, y => y.MapFrom(z => z.Conversa))
            .ForMember(x => x.Usuario, y => y.MapFrom(z => z.Usuario));
        }
    }
}