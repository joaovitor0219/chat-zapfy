using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatZapfy.DataTransfer.ConversasUsuarios.Requests
{
    public class ConversaUsuarioRequest
    {
        public int IdUsuario { get; set; }
        public int IdConversa { get; set; }
    }
}