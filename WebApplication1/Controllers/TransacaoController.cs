using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TransacaoController : Controller
    {

        private IHttpContextAccessor HttpContextAccessor;

        public TransacaoController(IHttpContextAccessor paramHttpContextAccessor)
        {
            HttpContextAccessor = paramHttpContextAccessor;
        }

        public IActionResult Index()
        {
            TransacaoModel objTransacao = new TransacaoModel(HttpContextAccessor);
            ViewBag.ListaTransacoes = objTransacao.SelecionarTransacoes();
            return View();
        }

        [HttpPost]
        public IActionResult Extrato(TransacaoModel formulario)
        {
            formulario.HttpContextAccessor = HttpContextAccessor;
            ViewBag.ListaTransacoes = formulario.SelecionarTransacoes();
            ViewBag.SaldoInicial = formulario.SelecionarTransacoesSaldoInicial();
            ViewBag.ListaContas = new ContaModel(HttpContextAccessor).ListaConta();
            return View();
        }

        [HttpGet]
        public IActionResult Extrato()
        {
            ViewBag.ListaContas = new ContaModel(HttpContextAccessor).ListaConta();
            ViewBag.SaldoInicial = 0;
            return View();
        }

        public IActionResult Dashboard()
        {

            ViewBag.Valores = "";
            ViewBag.Cores = "";
            ViewBag.Labels = "";

            Dashboard db = new Dashboard(HttpContextAccessor);
            List<Dashboard> lista = db.ObterDashboard();
            
            foreach (Dashboard item in lista)
            {
                ViewBag.Valores += item.Valor + ",";

                var random = new Random();
                var color = String.Format("#{0:X6}", random.Next(0x1000000)); // = "#A197B9"

                ViewBag.Cores += "'"+ color + "',";
                ViewBag.Labels += item.Descricao + ",";
            }

            return View();
        }

        [HttpGet]
        public IActionResult ExcluirTransacao(int id)
        {
            TransacaoModel item = new TransacaoModel(HttpContextAccessor);
            ViewBag.Registro = item.select(id);
            return View();
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            TransacaoModel transacao = new TransacaoModel(HttpContextAccessor);
            transacao.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Registrar(TransacaoModel formulario)
        {

            if (ModelState.IsValid)
            {
                formulario.HttpContextAccessor = HttpContextAccessor;
                formulario.insert();
                return RedirectToAction("Index");
            }

            ViewBag.ListaContas = new ContaModel(HttpContextAccessor).ListaConta();
            ViewBag.ListaPlanoContas = new PlanoContaModel(HttpContextAccessor).ListaPlanoConta();

            return View();

        }

        [HttpGet]
        public IActionResult Registrar(int? id)
        {

            if (id != null)
            {
                TransacaoModel item = new TransacaoModel(HttpContextAccessor);
                ViewBag.Registro = item.select(id);
            }

            ViewBag.ListaContas = new ContaModel(HttpContextAccessor).ListaConta();
            ViewBag.ListaPlanoContas = new PlanoContaModel(HttpContextAccessor).ListaPlanoConta();

            return View();

        }

        //ListaTransacoes
    }
}