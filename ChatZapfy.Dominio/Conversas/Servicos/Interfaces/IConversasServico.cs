using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatZapfy.Dominio.Conversas.Entidades;

namespace ChatZapfy.Dominio.Conversas.Servicos.Interfaces
{
    public interface IConversasServico
    {
        void Inserir(bool grupo, string nome);
        Conversa Editar(int id, string nome);
        Conversa Instanciar(bool grupo, string nome);
        void Excluir(int id);
        Conversa Validar(int id);
        IList<Conversa> RecuperarConversasPorUsuario(int idUsuario);
    }
}