using LojaNet.Models;
using LojaNet.UI.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LojaNet.UI.Web.Controllers
{
    public class PedidoController : Controller
    {
        private IPedidosDados bll;

        public PedidoController() { bll = AppContainer.ObterPedidoBLL(); }

        [HttpPost]
        public IActionResult Incluir(PedidoViewModel pedido)
        {
            var bllProduto = AppContainer.ObterProdutoBLL();
            var bllCliente = AppContainer.ObterClienteBLL();

            pedido.Clientes = bllCliente.ObterTodos();
            pedido.Produtos = bllProduto.ObterTodos();
            pedido.Produtos.Insert(0,new Produto() { Id = string.Empty,Nome=string.Empty });

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
                var pedidoModel = ObterModel(pedido);
                bll.Incluir(pedidoModel);
                return RedirectToAction("Index");
            }

            return View(pedido);
        }

        private Pedido ObterModel(PedidoViewModel pedidoViewModel)
        {
            var pedidoModel = new Pedido();
            pedidoModel.Id = Convert.ToInt32(pedidoViewModel.Id);
            pedidoModel.Data = pedidoViewModel.Data;
            pedidoModel.Cliente = new Cliente() { Id = pedidoViewModel.ClienteId };
            pedidoModel.FormaPagamento = pedidoViewModel.FormaPagamento;
            pedidoModel.Itens = new List<Pedido.Item>(); 

            int ordem = 1;
            foreach (var item in pedidoViewModel.Itens)
            {
                pedidoModel.Itens.Add(new Pedido.Item()
                {
                    Ordem = ordem,
                    Preco = item.Preco,
                    Produto = new Produto() { Id = item.ProdutoId },
                    Quantidade = item.Quantidade
                });
                ordem++;
            }
            return pedidoModel;
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

        public ActionResult Index()
        {
            var lista = bll.ObterTodos();
            return View(lista);
        }
    }
}
