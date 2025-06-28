using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatZapfy.Dominio.Mensagens.Producer.Comandos;
using ChatZapfy.Dominio.Mensagens.Servicos.Comandos;

namespace ChatZapfy.Dominio.Mensagens.Producer.Interfaces
{
    public interface IMensagemProducer
    {
        Task PublicarMensagemConsumer(MensagemComando comando, string routingKey);
    }
}