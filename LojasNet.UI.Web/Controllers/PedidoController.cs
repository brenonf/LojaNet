using LojaNet.UI.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaNet.UI.Web.Controllers
{
    public class PedidoController : Controller
    {
        public IActionResult Incluir()
        {
            var bllCliente = AppContainer.ObterClienteBLL();
            var pedido = new PedidoViewModel();
            pedido.Clientes=bllCliente.ObterTodos();
            return View(pedido);
        }
    }
}
