using LojaNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaNet.BLL
{
    public class ProdutoBLL : IProdutosDados
    {
        private IProdutosDados dal;

        public ProdutoBLL(IProdutosDados produtosDados)
        {
            this.dal = produtosDados;
        }

        public void Validar(Produto produto)
        {
            if(string.IsNullOrEmpty(produto.Nome))
            {
                throw new Exception("O nome deve ser informado");
            }
            if(produto.Preco<0)
            {
                throw new Exception("O preço deve ser maior ou igual a zero");
            }
        }

        public void Alterar(Produto produto)
        {
            Validar(produto);
            dal.Alterar(produto);
        }

        public void Excluir(string id)
        {
            dal.Excluir(id);
        }

        public void Incluir(Produto produto)
        {
            Validar(produto);
            if(string.IsNullOrEmpty(produto.Id))
            {
                produto.Id = Guid.NewGuid().ToString();
            }
            dal.Incluir(produto);
        }

        public Produto ObterPorId(string id)
        {
            return dal.ObterPorId(id);
        }

        public List<Produto> ObterTodos()
        {
            return dal.ObterTodos();
        }
    }
}
