using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoglass.Autoplay.Dominio.Util;
using AutoMapper;

namespace Autoglass.Autoplay.Aplicacao.Paginacao
{
    public class PaginacaoConsultasProfile : Profile
    {
        public PaginacaoConsultasProfile()
        {
            CreateMap(typeof(PaginacaoConsulta<>), typeof(PaginacaoConsulta<>));
        }
    }
}