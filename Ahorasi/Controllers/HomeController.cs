using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using Ahorasi.Permisos;
using Ahorasi.Models;


namespace Ahorasi.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [PermisosRol(Rol.Administrador)]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [PermisosRol(Rol.Administrador)]        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SinPermiso()
        {
            ViewBag.Message = "No cuenta con la autorizacion para revisar esta pagina";

            return View();
        }



        public ActionResult CerrarSesion()
        {


            FormsAuthentication.SignOut();
            Session["Usuario"] = null;

            return RedirectToAction("Index", "Acceso");
        }


        [HttpPost]
        public ActionResult Registro()
        {
            return RedirectToAction("Registro", "Acceso");
        }


    }
}