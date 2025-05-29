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
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace ChatZapfy.Infra.Mensagens.Publisher
{
    public class PublisherFilaRepositorio : IPublisherFilaRepositorio
    {
        private readonly IAmazonSQS amazonSQS;
        private readonly AwsConfig awsConfig;

        public PublisherFilaRepositorio(IAmazonSQS amazonSQS, AwsConfig awsConfig)
        {
            this.amazonSQS = amazonSQS;
            this.awsConfig = awsConfig;
        }

        public async Task PublicarAsync(MensagemComando comando)
        {
            var request = new SendMessageRequest
            {
                QueueUrl = awsConfig.QueueUrl,
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