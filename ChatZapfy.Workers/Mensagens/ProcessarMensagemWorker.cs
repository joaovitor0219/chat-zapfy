using Amazon.SQS;
using Amazon.SQS.Model;
using ChatZapfy.Aplicacao.Mensagens.Servicos.Interfaces;
using ChatZapfy.Dominio.ConfiguracoesAws;
using ChatZapfy.Dominio.Mensagens.Entidades;
using Microsoft.Extensions.Options;
using Quartz;
using Serilog.Context;

namespace ChatZapfy.Workers.Mensagens
{
    public class ProcessarMensagemWorker : IJob
    {
        private readonly ILogger<ProcessarMensagemWorker> logger;
        private readonly IOptions<AwsConfig> config;
        private readonly IMensagensAppServico mensagensAppServico;
        private readonly IAmazonSQS amazonSQS;


        public ProcessarMensagemWorker(ILogger<ProcessarMensagemWorker> logger, IMensagensAppServico mensagensAppServico, IOptions<AwsConfig> config, IAmazonSQS amazonSQS)
        {
            this.logger = logger;
            this.mensagensAppServico = mensagensAppServico;
            this.config = config;
            this.amazonSQS = amazonSQS;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            using (LogContext.PushProperty("TransactionId", context?.FireInstanceId ?? Guid.NewGuid().ToString()))
            using (LogContext.PushProperty("Job", context?.JobDetail.JobType.Name ?? GetType().FullName))
            {
                while (true)
                {
                    try
                    {
                        logger.LogInformation("<{EventoId}> - Executando {workerName}.", "ExecutandoWorker", "ProcessarMensagemWorker");

                        var request = new ReceiveMessageRequest
                        {
                            QueueUrl = config.Value.QueueUrl,
                            MaxNumberOfMessages = 1,
                            WaitTimeSeconds = 10
                        };

                        var response = await amazonSQS.ReceiveMessageAsync(request);

                        foreach (var message in response.Messages)
                        {
                            logger.LogInformation("<{EventoId}> - {Mensagem}.", "ProcessarMensagemWorker", "Processamendo mensagem");

                            await mensagensAppServico.InserirMensagens(message.Body);

                            await amazonSQS.DeleteMessageAsync(config.Value.QueueUrl, message.ReceiptHandle);

                            logger.LogInformation("<{EventoId}> - {Mensagem}.", "ProcessarMensagemWorker", "Mensagem processada e excluída");
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "<{EventoId} {Mensagem}>","ProcessarMensagemWorker", "Erro ao iniciar ao processar mensagem");
                    }
                    finally
                    {
                        await Task.CompletedTask;
                    }

                }
            }
        }
    }
}