using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatZapfy.DataTransfer.Conversas.Responses;
using ChatZapfy.DataTransfer.Usuarios.Responses;

namespace ChatZapfy.DataTransfer.ConversasUsuarios.Responses
{
    public class ConversaUsuarioResponse
    {
        public int Id { get; set; }
        public UsuarioResponse Usuario { get; set; }
        public ConversaResponse Conversa { get; set; }
    }
}