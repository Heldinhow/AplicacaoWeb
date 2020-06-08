using AplicacaoWeb.Models;
using Business;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace AplicacaoWeb.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logon(UsuarioModel usuarioModel)
        {
            
            var retorno = new UsuarioBusiness().BuscarUsuario(new Usuario { DS_USUARIO = usuarioModel.Login, DS_SENHA = usuarioModel.Senha});
            if (retorno.Valido)
                return RedirectToAction("Index", "Home");
            else
            {
                Session["ErroMessage"] = retorno.Mensagens != null ? string.Join(",", retorno.Mensagens) : string.Join(",", retorno.Excecao.Message);
                usuarioModel.Senha = string.Empty;
                return View("Login", usuarioModel);
            }

        }
        [HttpPost]
        public ActionResult SignUp(UsuarioModel usuarioModel)
        {
            Usuario usuario = new Usuario { DS_USUARIO = usuarioModel.Login, DS_SENHA = usuarioModel.Senha, DS_EMAIL_USUARIO = usuarioModel.Email };
            var retorno = new UsuarioBusiness().NovoUsuario(usuario);
            if (retorno.Valido)
            {
                return RedirectToAction("Login", "Login");
            }
            else
                return View();

        }
        [HttpPost]
        public JsonResult BuscarUsuario(string login)
        {
            var retorno = new UsuarioBusiness().UsuarioValido(login);
            if (!retorno.Valido)
            {
                Session["UsuarioValido"] = retorno.Mensagens != null ? string.Join(",", retorno.Mensagens) : string.Join(",", retorno.Excecao.Message);
            }
            return Json(retorno.Valido);
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
    }
}