namespace LojaNet.UI.Web.Models
{
    public partial class PedidoViewModel
    {
        public class Item
        {
            public string ProdutoId { get; set; }
            public string Nome { get; set; }
            public int Quantidade { get; set; }
            public decimal Valor { get; set; }
            public decimal Total
            {
                get { return Valor * Quantidade; }
            }
        }
    }
}
