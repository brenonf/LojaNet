using LojaNet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaNet.DAL
{
    internal class LojaContext : DbContext
    {
        public LojaContext():base(DbHelper.conexao)
        {
            
        }

        public DbSet<Produto> Produtos { get; set; }
    }
}
