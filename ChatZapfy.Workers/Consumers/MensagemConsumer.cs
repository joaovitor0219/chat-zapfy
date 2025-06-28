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
        private const string Exchange = "chat-topico";
        private readonly string[] Topicos = ["mensagem.info", "mensagem.warn"];
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
            consumer.Received += (ch, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var routingKey = ea.RoutingKey;

                Console.WriteLine($"[TOPICO: {routingKey}] Mensagem recebida: {message}");
            };

            model.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

            return Task.CompletedTask;
        }
    }
}