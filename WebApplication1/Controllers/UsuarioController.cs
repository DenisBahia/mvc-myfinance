using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.Controllers
{
    public class UsuarioController : Controller
    {

        [HttpGet]
        public IActionResult Login(int? id)
        {

            if (id != null)
            {
                if (id == 0)
                {
                    HttpContext.Session.SetString("NomeUsuarioLogado", "");
                    HttpContext.Session.SetString("IdUsuarioLogado", "");
                }
            }

            return View();

        }

        [HttpPost]
        public IActionResult ValidarLogin(UsuarioModel usuario)
        {
            bool login = usuario.ValidarLogin();
            if (login)
            {

                HttpContext.Session.SetString("NomeUsuarioLogado", usuario.Nome);
                HttpContext.Session.SetString("IdUsuarioLogado", usuario.id.ToString());

                return RedirectToAction("Menu", "Home");

            }
            else
            {
                TempData["MensagemLoginInvalido"] = "Dados para Login inválidos!";
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.RegistrarUsuario();
                return RedirectToAction("Sucesso");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Sucesso()
        {
            return View();
        }

    }
}