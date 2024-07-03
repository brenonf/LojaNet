using NUnit.Framework;
using LojaNet.DAL;
using Assert = NUnit.Framework.Assert;
using System;
using System.Net.Http;
using LojaNet.Models;
using System.Collections.Generic;

namespace LojaNet.Test
{
    [TestFixture]
    public class PedidoUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Incluir()
        {
            var pedido = new Pedido();
            pedido.Data = DateTime.Now;
            pedido.Cliente = new Cliente() { Id = "03cd6093-fca8-41cf-bca8-0226553a74b6", Nome = "Breno N. Faria", Telefone = "15161561", Email = "515155" };
            pedido.FormaPagamento = FormaPagamentoEnum.Pix;
            pedido.Itens = new List<Pedido.Item>();

            var item = new Pedido.Item();
            item.Produto = new Produto() { Id = "36ec80fe-553d-4486-bbe0-0b40331b3c5e", Nome = "Estojo", Preco = 15.90m, Estoque = 22 };
            item.Quantidade = 1;
            item.Ordem = 3;
            item.Preco = 15.90m;

            pedido.Itens.Add(item);



            item = new Pedido.Item();
            item.Produto = new Produto() { Id = "94ee0698-4eef-471e-985e-0edd84fbb727", Nome = "Papel", Preco = 11.99m, Estoque = 65 };
            item.Quantidade = 2;
            item.Ordem = 3;
            item.Preco = 11.99m;

            pedido.Itens.Add(item);


            var dal = new PedidoDAL();
            dal.Incluir(pedido);

        }
    
    }
}
