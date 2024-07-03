using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaNet.Models;
using System.Data.SqlClient;
using System.Data;

namespace LojaNet.DAL
{
    public class PedidoDAL : IPedidosDados
    {
        public void Alterar(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int pedidoId)
        {
            throw new NotImplementedException();
        }

        public void Incluir(Pedido pedido)
        {
            var cn = new SqlConnection(DbHelper.conexao);

            var cmd1 = new SqlCommand("PedidoIncluir");
            cmd1.Connection = cn;
            cmd1.CommandType = CommandType.StoredProcedure;

            var cmd2 = new SqlCommand("PedidoItemIncluir");
            cmd2.Connection = cn;
            cmd2.CommandType = CommandType.StoredProcedure;

            cn.Open();
            var tx = cn.BeginTransaction();

            try
            {
                cmd1.Transaction = tx;
                cmd2.Transaction = tx;

                cmd1.Parameters.AddWithValue("@Data", pedido.Data);
                cmd1.Parameters.AddWithValue("@ClienteId", pedido.Cliente.Id);
                cmd1.Parameters.AddWithValue("@FormaPagamentoId", pedido.FormaPagamento);

                pedido.Id = Convert.ToInt32(cmd1.ExecuteScalar());

                int ordem = 1;
                cmd2.Parameters.AddWithValue("@PedidoId", pedido.Id);
                cmd2.Parameters.AddWithValue("@Ordem", 0);
                cmd2.Parameters.AddWithValue("@Quantidade", 0);
                cmd2.Parameters.AddWithValue("@Preco", Convert.ToDecimal(0));
                cmd2.Parameters.AddWithValue("@ProdutoId", string.Empty);



                foreach (var item in pedido.Itens)
                {
                    cmd2.Parameters["@ProdutoId"].Value = item.Produto.Id;
                    cmd2.Parameters["@Ordem"].Value = ordem;
                    cmd2.Parameters["@Quantidade"].Value = item.Quantidade;
                    cmd2.Parameters["@Preco"].Value = item.Preco;
                    cmd2.ExecuteNonQuery();
                    ordem += 1;
                }

                tx.Commit();
            }
            catch(Exception ex) 
            { 
                tx.Rollback();
                throw new Exception("Erro no servidor:" + ex.Message);
            }
            finally
            { cn.Close(); }

        }

        public Pedido ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pedido> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
