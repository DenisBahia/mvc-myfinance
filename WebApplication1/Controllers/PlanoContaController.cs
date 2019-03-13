using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PlanoContaController : Controller
    {

        private IHttpContextAccessor HttpContextAccessor;

        public PlanoContaController(IHttpContextAccessor paramHttpContextAccessor)
        {
            HttpContextAccessor = paramHttpContextAccessor;
        }

        public IActionResult Index()
        {
            PlanoContaModel objConta = new PlanoContaModel(HttpContextAccessor);
            ViewBag.ListaPlanoContas = objConta.ListaPlanoConta();
            return View();
        }

        [HttpPost]
        public IActionResult CriarPlanoConta(PlanoContaModel formulario)
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
        public IActionResult CriarPlanoConta(int? id)
        {
            if (id != null)
            {
                PlanoContaModel conta = new PlanoContaModel(HttpContextAccessor);
                ViewBag.Registro = conta.SelecionarPorId(id);
            }
            return View();
        }

        [HttpGet]
        public IActionResult ExcluirPlanoConta(int id)
        {
            PlanoContaModel conta = new PlanoContaModel(HttpContextAccessor);
            conta.Delete(id);
            return RedirectToAction("Index");
        }

    }
}