using System;
using Microsoft.AspNetCore.Mvc;
using LojaNet.Models;
using LojaNet.BLL;
using Microsoft.AspNetCore.Http;

namespace LojasNet.UI.Web.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteBLL bll;

        public ClienteController()
        {
            bll = new ClienteBLL();
        }

        public ActionResult Detalhes(string id)
        {
            var cliente =bll.ObterPorId(id);
            return View(cliente);
        }

        public ActionResult Alterar(string id)
        {
            var cliente = bll.ObterPorId(id);
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Alterar(Cliente cliente)
        {
            try
            {
                bll.Alterar(cliente);
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(cliente);
            }
        }

        public ActionResult Incluir()
        {
            var cliente = new Cliente();
            return View(cliente); 
        }

        [HttpPost]
        public ActionResult Incluir(Cliente cliente)
        {
            try
            {
                bll.Incluir(cliente);
                return RedirectToAction("index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(cliente);
            }
        }

        public ActionResult Excluir(string id)
        {
            var cliente = bll.ObterPorId(id);
            return View(cliente);
        }

        [HttpPost]
        public ActionResult ConfirmarExcluir(string id)
        {
            try
            {
                bll.Excluir(id);
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                var cliente = bll.ObterPorId(id);
                return View(cliente);
            }
        }

        public IActionResult Index()
        {
            var lista = bll.ObterTodos();
            return View(lista);
        }
    }
}
