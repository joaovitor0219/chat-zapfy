using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ChatZapfy.Aplicacao.Notificacoes.Servicos.Interfaces;
using ChatZapfy.Dominio.Mensagens.Producer.Comandos;
using ChatZapfy.Dominio.Mensagens.Servicos.Comandos;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ChatZapfy.Workers.Consumers
{
    public class MensagemConsumer : BackgroundService
    {
        private const string Exchange = "chat-mensagens";
        private const string QueueName = "fila-mensagem-consumer";
        private readonly INotificacoesAppServico notificacoesAppServico;

        public MensagemConsumer(INotificacoesAppServico notificacoesAppServico)
        {
            this.notificacoesAppServico = notificacoesAppServico;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var model = connection.CreateModel();

            model.ExchangeDeclare(Exchange, ExchangeType.Fanout, durable: true);
            model.QueueDeclare(QueueName, durable: false, exclusive: false, autoDelete: false);
            model.QueueBind(QueueName, Exchange, "");

            var consumer = new EventingBasicConsumer(model);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var json = Encoding.UTF8.GetString(body);
                var mensagem = JsonSerializer.Deserialize<MensagemComando>(json);

                await notificacoesAppServico.CriarNotificaoAsync();

                Console.WriteLine($"Mensagem recebida: Usuario {mensagem?.IdUsuario} disse: {mensagem?.Conteudo}");
            };
            model.BasicConsume(QueueName, autoAck: true, consumer: consumer);

            return Task.CompletedTask;

        }
    }
}