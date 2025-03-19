using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatZapfy.DataTransfer.Usuarios.Requests
{
    public class UsuarioRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}