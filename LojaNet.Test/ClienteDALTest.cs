using NUnit.Framework;
using LojaNet.DAL;
using Assert = NUnit.Framework.Assert;
using System;
using System.Net.Http;

namespace LojaNet.Test
{
    [TestFixture]
    public class ClienteDALTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ObterPorEmailNullTest() 
        {
            string email = null;
            var dal = new ClienteDAL();
            bool ok = false;
            try
            {
                var cliente = dal.ObterPorEmail(email);
            }
            catch(ApplicationException ex) 
            {
                if (ex.Message == "O email deve ser informado")
                {
                    ok = true;
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Erro no Servidor. Parametro não informado: "+ex.Message);
            }
            Assert.IsTrue(ok, "Deveria ter disparado um ApplicationException com a mensagem \"O email deveria ser informado\"");

        }


        [Test]
        public void ObterPorEmailTest()
        {
            string email = "maria@teste.com";
            var dal = new ClienteDAL();
            var cliente = dal.ObterPorEmail(email);

            if(cliente != null) 
            {
                Console.WriteLine("Cliente Encontrado:");
                Console.WriteLine(cliente.Id);
                Console.WriteLine(cliente.Nome);
                Console.WriteLine(cliente.Email);
                Console.WriteLine(cliente.Telefone);
            }

            Assert.IsTrue(cliente != null, "Deveria ter retornado uma instância de um cliente");
        }
    }
}
