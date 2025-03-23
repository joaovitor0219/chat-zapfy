using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatZapfy.DataTransfer.Conversas.Responses
{
    public class ConversaResponse
    {
        public int Id { get; set; }
        public virtual bool Grupo { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual DateTime DataInclusao { get; protected set; }
    }
}