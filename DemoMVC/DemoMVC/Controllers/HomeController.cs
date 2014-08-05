using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class HomeController : Controller
    {
        Models.Mensajes msj = new Models.Mensajes();

        public ActionResult Index()
        {
            Models.Personas persona = new Models.Personas();

            if (msj.mensaje == null)
            {
                msj.mensaje = "";
            }

            ViewData["msj"] = msj.mensaje;
            ViewBag.Msj = 10;

            return View(persona);
        }

        [HttpPost]
        public ActionResult Index(Models.Personas persona)
        {
            msj.mensaje = "se realiza envio del modelo de nuevo a la vista";
            ViewData["msj"] = msj.mensaje;
            ViewBag.Msj = 10;

            return View(persona);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}