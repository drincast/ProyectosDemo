using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace DemoMVC.Controllers
{
    public class BuscarOpcionProcController : Controller
    {
        //
        // GET: /BuscarOpcionProc/
        public ActionResult Index(int? page)
        {
            Models.ModelOpcionesProcs objMOpciones = null;
            string strCodTipo = ViewBag.codTipo;
            string strCodTipo2 = "";

            if (this.HttpContext.Cache["codTipo"] != null)
            {
                strCodTipo2 = this.HttpContext.Cache["codTipo"].ToString();
            }

            DataTable dt = null;
            Models.CDatos objDatos = null;
            Models.OpcionPorcs objOpcProc = null;

            if(page == null)
            {
                objMOpciones = new Models.ModelOpcionesProcs();

                ViewBag.lstOpcProc = null;
            }
            else
            {
                objDatos = new Models.CDatos();
                objMOpciones = new Models.ModelOpcionesProcs();

                string consulta = string.Format("SELECT opcNumero, opcTipo, opcCodigo, opcNombre, opcInactivo, opcCodGral, opcOrden, opcTipoOpcion, opcParametro FROM hisOpcionesProcs WHERE opcTipo LIKE '{0}'", strCodTipo2);
                dt = objDatos.EjecutarConsultaTabla(consulta);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        objOpcProc = new Models.OpcionPorcs();

                        objOpcProc.numero = Convert.ToInt32(dr["opcNumero"].ToString());
                        objOpcProc.tipo = dr["opcTipo"].ToString();
                        objOpcProc.codigo = dr["opcCodigo"].ToString();
                        objOpcProc.inactivo = Convert.ToBoolean(dr["opcInactivo"].ToString());
                        objOpcProc.nombre = dr["opcNombre"].ToString();
                        objOpcProc.codigoGeneral = dr["opcCodGral"].ToString();
                        objOpcProc.orden = Convert.ToInt32(dr["opcOrden"].ToString());
                        objOpcProc.tipoOpcion = Convert.ToInt16(dr["opcTipoOpcion"].ToString());
                        objOpcProc.parametro = dr["opcParametro"].ToString();

                        objMOpciones.lstObjOpciones.Add(objOpcProc);
                    }

                    ViewBag.lstOpcProc = objMOpciones.lstObjOpciones;
                }
            }

            return View(objMOpciones);
        }

        // POST: /BuscarOpcionProc/
        [HttpPost]
        public ActionResult Index(Models.ModelOpcionesProcs objMOpciones)
        {
            string strTipo = objMOpciones.objTipoBuscar.tipoBuscar;
            string msjError = "";
            Models.CDatos objDatos = null;
            DataTable dt = null;
            Models.OpcionPorcs objOpcProc = null;

            try
            {
                objDatos = new Models.CDatos();

                string consulta = string.Format("SELECT opcNumero, opcTipo, opcCodigo, opcNombre, opcInactivo, opcCodGral, opcOrden, opcTipoOpcion, opcParametro FROM hisOpcionesProcs WHERE opcTipo LIKE '{0}'", objMOpciones.objTipoBuscar.tipoBuscar);
                dt = objDatos.EjecutarConsultaTabla(consulta);

                ViewBag.codTipo = objMOpciones.objTipoBuscar.tipoBuscar;

                if (dt.Rows.Count > 0)
                { 
                    foreach (DataRow dr in dt.Rows)
                    {
                        objOpcProc = new Models.OpcionPorcs();

                        objOpcProc.numero = Convert.ToInt32(dr["opcNumero"].ToString());
                        objOpcProc.tipo = dr["opcTipo"].ToString();
                        objOpcProc.codigo = dr["opcCodigo"].ToString();
                        objOpcProc.inactivo = Convert.ToBoolean(dr["opcInactivo"].ToString());
                        objOpcProc.nombre = dr["opcNombre"].ToString();
                        objOpcProc.codigoGeneral = dr["opcCodGral"].ToString();
                        objOpcProc.orden = Convert.ToInt32(dr["opcOrden"].ToString());
                        objOpcProc.tipoOpcion = Convert.ToInt16(dr["opcTipoOpcion"].ToString());
                        objOpcProc.parametro = dr["opcParametro"].ToString();

                        objMOpciones.lstObjOpciones.Add(objOpcProc);
                    }

                    ViewBag.lstOpcProc = objMOpciones.lstObjOpciones;
                }
            }
            catch (Exception ex)
            {
                msjError = string.Format("Error: ", ex.Message);
                ViewBag.msjError = msjError;
                //throw;
            }

            return View(objMOpciones);
        }

        //
        // GET: /BuscarOpcionProc/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /BuscarOpcionProc/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /BuscarOpcionProc/Create
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
        // GET: /BuscarOpcionProc/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /BuscarOpcionProc/Edit/5
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
        // GET: /BuscarOpcionProc/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /BuscarOpcionProc/Delete/5
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
