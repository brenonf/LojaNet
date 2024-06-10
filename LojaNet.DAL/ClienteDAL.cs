using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaNet.Models;

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
