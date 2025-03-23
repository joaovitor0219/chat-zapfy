using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatZapfy.DataTransfer.Conversas.Requests;
using ChatZapfy.DataTransfer.Conversas.Responses;

namespace ChatZapfy.Aplicacao.Conversas.Servicos.Interfaces
{
    public interface IConversasAppServico
    {
        void Inserir(ConversaRequest request);
        ConversaResponse Recuperar(int id);
        void Excluir(int id);
        ConversaResponse Editar(int id, ConversaRequest request);
    }
}