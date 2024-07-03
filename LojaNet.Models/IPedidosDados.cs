using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaNet.Models
{
    public interface IPedidosDados
    {
        void Incluir(Pedido pedido);
        void Alterar(Pedido pedido);
        void Excluir(int pedidoId);

        List<Pedido> ObterTodos();
        Pedido ObterPorId(int id);
    }
}
