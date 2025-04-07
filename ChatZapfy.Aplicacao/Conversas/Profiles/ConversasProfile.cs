using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ChatZapfy.DataTransfer.Conversas.Requests;
using ChatZapfy.DataTransfer.Conversas.Responses;
using ChatZapfy.Dominio.Conversas.Entidades;
using ChatZapfy.Dominio.Conversas.Repositorios.Filtros;
using CsvHelper.Configuration;

namespace ChatZapfy.Aplicacao.Conversas.Profiles
{
    public class ConversasProfile : Profile
    {
        public ConversasProfile()
        {
            CreateMap<Conversa, ConversaResponse>();
            CreateMap<ConversasListarRequest, ConversaListarFiltro>();
        }
        
    }
}