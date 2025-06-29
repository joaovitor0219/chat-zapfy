using System.Text;
using System.Text.Json;
using ChatZapfy.Aplicacao.Notificacoes.Servicos.Interfaces;
using ChatZapfy.DataTransfer.Notificacoes.Requests.Requests;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ChatZapfy.Workers.Consumers
{
    public class MensagemConsumer : BackgroundService
    {
        private const string Exchange = "chat-topico";
        private readonly string[] Topicos = ["mensagem.info", "mensagem.warn"];
        private readonly IServiceProvider servico;

        public MensagemConsumer(IServiceProvider servico)
        {
            this.servico = servico;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var model = connection.CreateModel();

            model.ExchangeDeclare(Exchange, ExchangeType.Topic, durable: true);

            var queueName = model.QueueDeclare().QueueName;

            foreach (var routingKey in Topicos)
            {
                model.QueueBind(queue: queueName, exchange: Exchange, routingKey: routingKey);
            }

            var consumer = new EventingBasicConsumer(model);
            consumer.Received += async (ch, ea) =>
            {
                using var scope = servico.CreateScope();
                var notificacoesAppServico = scope.ServiceProvider.GetRequiredService<INotificacoesAppServico>();

                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var routingKey = ea.RoutingKey;

                var request = JsonSerializer.Deserialize<NotificacaoRequest>(message);

                await notificacoesAppServico.CriarNotificaoAsync(request);
            };

            model.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

            return Task.CompletedTask;
        }
    }
}