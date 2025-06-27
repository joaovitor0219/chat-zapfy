using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatZapfy.Dominio.Mensagens.Producer.Comandos
{
    public class MensagemRabbitMQComando
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataEnvio { get; set; }

    }
}