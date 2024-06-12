using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using LojaNet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Abstractions;


namespace LojaNet.DAL
{
    public class ClienteDAL : IClienteDados
    {
        public void Alterar(Cliente cliente)
        {
            DbHelper.ExecuteNonQuery("ClienteAlterar",
                "@Id", cliente.Id,
                "@Nome", cliente.Nome,
                "@Email", cliente.Email,
                "@Telefone", cliente.Telefone
                );
        }

        public void Excluir(string Id)
        {
            /*string pasta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data");
            string arquivo = Path.Combine(pasta, $"Cliente_{Id}.xml");*/
            string pasta = Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString());
            string arquivo = Path.Combine(pasta, $"Cliente_{Id}.xml");

            //string arquivo = @"C:\Users\Breno\Desktop\Breno\C#\visualizador\teste.xml";

            Cliente cliente = ObterPorId(Id);
            SerializadorHelper.Serializar(arquivo, cliente);
            DbHelper.ExecuteNonQuery("ClienteExcluir", "@Id", Id);                        
        }

        public void Incluir(Cliente cliente)
        {
            DbHelper.ExecuteNonQuery("ClienteIncluir",
                "@Id",cliente.Id,
                "@Nome",cliente.Nome,
                "@Email",cliente.Email,
                "@Telefone",cliente.Telefone
                );
        }

        public Cliente ObterPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Cliente ObterPorId(string Id)
        {
            Cliente cliente = null;
            using(var reader =DbHelper.ExecuteReader("ClienteObterPorId","@Id",Id))
            {
                if(reader.Read())
                {
                    cliente = ObterClienteReader(reader);
                }
            }
            return cliente;
        }

        public List<Cliente> ObterTodos()
        {
            var lista = new List<Cliente>();
            using (var reader = DbHelper.ExecuteReader("ClienteListar"))
            {
                while (reader.Read())
                {
                    Cliente cliente = ObterClienteReader(reader);

                    lista.Add(cliente);
                }

            }
            return lista;
        }

        private static Cliente ObterClienteReader(IDataReader reader)
        {
            var cliente = new Cliente();
            cliente.Id = reader["Id"].ToString();
            cliente.Nome = reader["Nome"].ToString();
            cliente.Email = reader["Email"].ToString();
            cliente.Telefone = reader["Telefone"].ToString();
            return cliente;
        }
    }
}
