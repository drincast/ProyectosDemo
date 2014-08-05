using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class MapsController : Controller
    {
        //
        // GET: /Maps/
        //public ActionResult Index()
        //{
        //    //return View();
        //    throw new NotImplementedException();
        //}

        public ActionResult ViewMaps()
        {
            return View();
        }
	}
}