using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatZapfy.Dominio.Mensagens.Servicos.Comandos;

namespace ChatZapfy.Dominio.Mensagens.Publisher.Interfaces
{
    public interface IPublisherFilaRepositorio
    {
        Task PublicarAsync(MensagemComando comando);
    }
}