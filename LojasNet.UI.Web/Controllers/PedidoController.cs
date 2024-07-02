using LojaNet.Models;
using LojaNet.UI.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace LojaNet.UI.Web.Controllers
{
    public class PedidoController : Controller
    {
        [HttpPost]
        public IActionResult Incluir(PedidoViewModel pedido)
        {
            var bllProduto = AppContainer.ObterProdutoBLL();
            var bllCliente = AppContainer.ObterClienteBLL();

            pedido.Clientes = bllCliente.ObterTodos();
            pedido.Produtos = bllProduto.ObterTodos();
            pedido.FormasPagamento = Enum.GetNames(typeof(FormaPagamentoEnum)).ToList();


            if (Request.Form["incluirProduto"]=="Incluir")
            {
                var item = new PedidoViewModel.Item();
                item.ProdutoId=pedido.NovoItemProdutoId;
                item.Quantidade=pedido.NovoItemQuantidade;

                var produto=bllProduto.ObterPorId(item.ProdutoId);
                item.Valor = produto.Preco;
                item.Nome = produto.Nome;
                pedido.Itens.Add(item);
            }

            else if (Request.Form["Gravar"]=="Gravar")
            {
                //var bll = AppContainer.ObterPedidoBll();

            }

            return View(pedido);
        }
        public IActionResult Incluir()
        {
            var bllCliente = AppContainer.ObterClienteBLL();
            var bllProduto = AppContainer.ObterProdutoBLL();

            var pedido = new PedidoViewModel();
            pedido.Clientes=bllCliente.ObterTodos();
            pedido.Produtos=bllProduto.ObterTodos();
            pedido.FormasPagamento = Enum.GetNames(typeof(FormaPagamentoEnum)).ToList();



            

            return View(pedido);
        }
    }
}
