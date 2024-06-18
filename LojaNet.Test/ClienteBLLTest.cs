using NUnit.Framework;
using LojaNet.DAL;
using Assert = NUnit.Framework.Assert;
using System;
using System.Net.Http;
using LojaNet.Models;
using LojaNet.BLL;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

namespace LojaNet.Test
{
    [TestFixture]
    public class ClienteBLLTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        public class ClienteDALMock : IClienteDados
        {
            public void Alterar(Cliente cliente)
            {}

            public void Excluir(string id)
            {}

            public void Incluir(Cliente cliente)
            {}

            public Cliente ObterPorEmail(string email)
            {
                return null;
            }

            public Cliente ObterPorId(string id)
            {
                return null;
            }

            public List<Cliente> ObterTodos()
            {
                return null;
            }
        }

        [Test]
        public void IncluirNomeNullTest() 
        {
            var cliente = new Cliente()
            {
                Nome = null,
                Email = "email@teste.com",
                Telefone = "1234-5678"
            };
            var dal = new ClienteDAL();
            var bll = new ClienteBLL(dal);

            bool ok = false;

            try
            {
                bll.Incluir(cliente);                
            }
            catch(ApplicationException) 
            {
                ok = true;
            }
            Assert.IsTrue(ok,"Deveria ter disparado um Exception");
        }

        [Test]
        public void IncluirNomeNotNullTest()
        {
            var cliente = new Cliente()
            {
                Nome = "Sebastião dos Santos",
                Email = "email@teste.com",
                Telefone = "9999-9876"
            };
            var dal = new ClienteDALMock();
            var bll = new ClienteBLL(dal);

            bool ok = false;

            try
            {
                bll.Incluir(cliente);
                ok = true;
            }
            catch (ApplicationException)
            {
                ok = false;
            }
            Assert.IsTrue(ok, "Deveria ter disparado um Exception");
        }
    }
}
