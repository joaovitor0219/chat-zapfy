using AutoMapper;
using ChatZapfy.DataTransfer.Notificacoes.Requests.Requests;
using ChatZapfy.Dominio.Notificacoes.Servicos.Comandos;

namespace ChatZapfy.Aplicacao.Notificacoes.Profiles;

public class NotificacoesProfile : Profile
{
    public NotificacoesProfile()
    {
        CreateMap<NotificacaoRequest, NotificacaoComando>();
    }
}
