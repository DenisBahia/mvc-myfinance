using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ContaController : Controller
    {

        private IHttpContextAccessor HttpContextAccessor;

        public ContaController(IHttpContextAccessor paramHttpContextAccessor)
        {
            HttpContextAccessor = paramHttpContextAccessor;
        }

        public IActionResult Index()
        {
            ContaModel objConta = new ContaModel(HttpContextAccessor);
            ViewBag.ListaContas = objConta.ListaConta();
            return View();
        }

        [HttpPost]
        public IActionResult CriarConta(ContaModel formulario)
        {
            if (ModelState.IsValid)
            {
                formulario.HttpContextAccessor = HttpContextAccessor;
                formulario.Insert();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult CriarConta()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ExcluirConta(int id)
        {
            ContaModel conta = new ContaModel(HttpContextAccessor);
            conta.Delete(id);
            return RedirectToAction("Index");
        }

    }
}