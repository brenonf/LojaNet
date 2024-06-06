using System;
using Microsoft.AspNetCore.Mvc;
using LojaNet.Models;
using LojaNet.BLL;

namespace LojasNet.UI.Web.Controllers
{
    public class ClienteController : Controller
    {
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
                var bll = new ClienteBLL();
                bll.Incluir(cliente);
                return RedirectToAction("index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(cliente);
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
