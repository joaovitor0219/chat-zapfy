using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;
using AplicativoTarefa.Dominio.Execoes;
using ChatZapfy.Dominio.ConfiguracoesAws;
using ChatZapfy.Dominio.Mensagens.Publisher.Interfaces;
using ChatZapfy.Dominio.Mensagens.Servicos.Comandos;
using Microsoft.Extensions.Options;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace ChatZapfy.Infra.Mensagens.Publisher
{
    public class PublisherFilaRepositorio : IPublisherFilaRepositorio
    {
        private readonly IAmazonSQS amazonSQS;
        private readonly IOptions<AwsConfig> config;

        public PublisherFilaRepositorio(IAmazonSQS amazonSQS,IOptions<AwsConfig> config)
        {
            this.amazonSQS = amazonSQS;
            this.config = config;
        }

        public async Task PublicarAsync(MensagemComando comando)
        {
            var request = new SendMessageRequest
            {
                QueueUrl = config.Value.QueueUrl,
                MessageBody = JsonSerializer.Serialize(comando)
            };

            var response = await amazonSQS.SendMessageAsync(request);

            if (response.HttpStatusCode != HttpStatusCode.OK)
            {
                throw new RegraDeNegocioExcecao("Erro ao publicar a mensagem na fila");
            }
        }
    }
}