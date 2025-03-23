using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatZapfy.DataTransfer.ConversasUsuarios.Requests;
using ChatZapfy.DataTransfer.ConversasUsuarios.Responses;

namespace ChatZapfy.Aplicacao.ConversasUsuarios.Servicos.Interfaces
{
    public interface IConversasUsuariosAppServico
    {
        void Inserir(ConversaUsuarioRequest request);
        ConversaUsuarioResponse Recuperar(int id);
        void Excluir(int id);
    }
}