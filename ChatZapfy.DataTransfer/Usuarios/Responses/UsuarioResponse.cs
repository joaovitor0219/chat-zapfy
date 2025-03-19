using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatZapfy.DataTransfer.Usuarios.Responses
{
    public class UsuarioResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataInclusao { get; set; }
    }
}