using LojaNet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LojaNet.UI.Web.Models
{
    public partial class PedidoViewModel
    {
        public PedidoViewModel()
        {
            this.Clientes = new List<Cliente>();
            this.Produtos = new List<Produto>();
            this.FormasPagamento = new List<string>();
            this.Itens = new List<Item>();
            this.Data = DateTime.Now;
        }
        public string NovoItemProdutoId { get; set; }
        public int NovoItemQuantidade { get; set; }

        public string Id { get; set; }
        public DateTime Data { get; set; }
        public List<Cliente> Clientes { get; set; }
        public string ClienteId { get; set; }
        public List<Item> Itens { get; set; }
        public FormaPagamentoEnum FormaPagamento { get; set; }
        public List<string> FormasPagamento { get; set; }
        public List<Produto> Produtos{ get; set; }
    }
}
