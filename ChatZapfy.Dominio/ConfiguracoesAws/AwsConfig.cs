using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatZapfy.Dominio.ConfiguracoesAws
{
    public class AwsConfig
    {
        public string Region { get; set; }
        public string QueueUrl { get; set; }
    }
}