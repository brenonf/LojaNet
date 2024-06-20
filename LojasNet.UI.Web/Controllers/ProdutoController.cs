using LojaNet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LojaNet.UI.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private IProdutosDados bll;

        public ProdutoController()
        {
            bll = AppContainer.ObterProdutoBLL();
        }

        public IActionResult Index()
        {
            var lista = bll.ObterTodos();
            return View(lista);
        }
        public ActionResult Detalhes(string id)
        {
            var produto = bll.ObterPorId(id);
            return View(produto);
        }

        public ActionResult Alterar(string id)
        {
            var produto = bll.ObterPorId(id);
            return View(produto);
        }

        [HttpPost]
        public ActionResult Alterar(Produto produto)
        {
            try
            {
                bll.Alterar(produto);
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(produto);
            }
        }

        public ActionResult Incluir()
        {
            var produto = new Produto();
            return View(produto);
        }

        [HttpPost]
        public ActionResult Incluir(Produto produto)
        {
            try
            {
                bll.Incluir(produto);
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(produto);
            }
        }

        public ActionResult Excluir(string id)
        {
            var produto = bll.ObterPorId(id);
            return View(produto);
        }

        [HttpPost]
        public ActionResult Excluir(string id, IFormCollection form)
        {
            try
            {
                bll.Excluir(id);
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                var produto = bll.ObterPorId(id);
                return View(produto);
            }
        }
    }
}
