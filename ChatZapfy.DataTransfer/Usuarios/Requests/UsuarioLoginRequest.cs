using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatZapfy.DataTransfer.Usuarios.Requests
{
    public class UsuarioLoginRequest
    {
        public string Senha { get; set; }
        public string Nome { get; set; }
    }
}