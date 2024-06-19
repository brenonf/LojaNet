using NUnit.Framework;
using LojaNet.DAL;
using Assert = NUnit.Framework.Assert;
using System;
using System.Net.Http;
using LojaNet.Models;

namespace LojaNet.Test
{
    [TestFixture]
    public class ProdutoDALTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Incluir()
        {
            var produto = new Produto();
            produto.Id= Guid.NewGuid().ToString();
            produto.Nome = "Produto Teste";
            produto.Preco = 100;
            produto.Estoque = 2;

            var dal = new ProdutoDAL();
            dal.Incluir(produto);

            var p= dal.ObterPorId(produto.Id);

            Assert.IsTrue(p.Id != null, "Erro na inclusão!");
        }

        [Test]
        public void Listar()
        {
            var dal = new ProdutoDAL();
            var lista = dal.ObterTodos();

            foreach(var p in lista)
            { 
                Console.WriteLine($"{p.Id}\n{p.Nome}\n{p.Preco}\n{p.Estoque}"); 
            }

            Assert.IsTrue(lista.Count > 0, "A lista não pode ser vazia");
        }

    }
}
