using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace ChatZapfy.API.Hubs
{
    public class ChatHub : Hub
    {
        public async Task EnviarMensagem(int idUsuario, string usuario, string mensagem)
        {
            await Clients.All.SendAsync("ReceberMensagem", idUsuario, usuario, mensagem);
        }   
    }
}