using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace DemoMVC.Controllers
{
    public class Opciones1Controller : Controller
    {
        //instancia
        DemoMVC.Models.SiamDev2012Entities1 entityDatos = new Models.SiamDev2012Entities1();

        //
        // GET: /Opciones1/
        public ActionResult Index()
        {
            ViewData["opciones"] = new SelectList(entityDatos.prcHCObtenerOpcionesDatos("00001").ToList());



            List<Models.MDatos1> lstDatos = new List<Models.MDatos1>();
            Models.MDatos1 objDato;

            try 
	        {
		        Models.CDatos objDatos = new Models.CDatos();
                string consulta = String.Format("EXEC prcHCObtenerOpcionesDatos '{0}'", "00001");
                DataTable dt = objDatos.EjecutarConsultaTabla(consulta);

                foreach (DataRow dr in dt.Rows)
                {
                    objDato = new Models.MDatos1();
                    objDato.Codigo = dr["Codigo"].ToString();
                    objDato.Inactivo = Convert.ToBoolean(dr["Inactivo"].ToString());
                    objDato.Opcion = dr["Opcion"].ToString();
                    objDato.Orden = Convert.ToInt32(dr["Orden"].ToString());
                    objDato.Parametro = dr["Parametro"].ToString();
                    objDato.Tipo = dr["Tipo"].ToString();
                    objDato.TipoOpcion = Convert.ToByte(dr["TipoOpcion"].ToString());
                    lstDatos.Add(objDato);
                }
	        }
	        catch (Exception)
	        {		
		        throw ;
	        }

            return View(lstDatos);
        }

        //[HttpPost]
        //public ActionResult Index()
        //{
        //    return View(entityDatos.prcHCObtenerOpcionesDatos("00001").ToList());
        //}

        //
        // GET: /Opciones1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Opciones1/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Opciones1/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Opciones1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Opciones1/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Opciones1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Opciones1/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
