using LojaNet.BLL;
using LojaNet.DAL;
using LojaNet.Models;

namespace LojaNet.UI.Web
{
    public static class AppContainer
    {
        public static IClienteDados ObterClienteBLL()
        {
            var dal = new ClienteDAL();
            var bll = new ClienteBLL(dal);
            return bll;
        }

        public static IProdutosDados ObterProdutoBLL()
        {
            var dal = new ProdutoDAL();
            var bll = new ProdutoBLL(dal);
            return bll;
        }

        public static IPedidosDados ObterPedidoBLL()
        {
            var dal = new PedidoDAL();
            var bll = new PedidoBLL(dal);
            return bll;
        }
    }

}
