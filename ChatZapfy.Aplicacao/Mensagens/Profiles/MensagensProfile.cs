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
        CreateMap<Mensagem, MensagemResponse>()
        .ForMember(x => x.Conversa, y => y.MapFrom(z => z.Conversa))
        .ForMember(x => x.Usuario, y => y.MapFrom(z => z.Usuario));
        CreateMap<MensagemListarRequest, MensagemListarFiltro>();
    }
}
