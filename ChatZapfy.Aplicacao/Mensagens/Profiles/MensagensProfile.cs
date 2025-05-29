using AutoMapper;
using ChatZapfy.DataTransfer.Mensagens.Requests;
using ChatZapfy.DataTransfer.Mensagens.Responses.Responses;
using ChatZapfy.Dominio.Mensagens.Entidades;
using ChatZapfy.Dominio.Mensagens.Repositorios.Filtros;

namespace ChatZapfy.Aplicacao.Mensagens.Profiles;

public class MensagensProfile : Profile
{
    public MensagensProfile()
    {
        CreateMap<Mensagem, MensagemResponse>();
        CreateMap<MensagemListarRequest, MensagemListarFiltro>();
    }
}
