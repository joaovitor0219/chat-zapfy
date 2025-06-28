using System.Text;
using System.Text.Json;
using ChatZapfy.Dominio.Mensagens.Producer.Comandos;
using ChatZapfy.Dominio.Mensagens.Producer.Interfaces;
using ChatZapfy.Dominio.Mensagens.Servicos.Comandos;
using RabbitMQ.Client;


namespace ChatZapfy.Infra.Mensagens.Producer
{
    public class MensagemProducer : IMensagemProducer
    {

        private readonly IConnection connection;
        private readonly IModel model;

        private const string Exchange = "chat-topico";

        public MensagemProducer()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            connection = factory.CreateConnection();

            model = connection.CreateModel();
        }

        public Task PublicarMensagemConsumer(MensagemComando comando, string routingKey)
        {
            var mensagem = JsonSerializer.Serialize(comando);
            var body = Encoding.UTF8.GetBytes(mensagem);

            model.BasicPublish(
                exchange: Exchange,
                routingKey: routingKey,
                basicProperties: null,
                body: body
            );

            return Task.CompletedTask;
        }
    }
}