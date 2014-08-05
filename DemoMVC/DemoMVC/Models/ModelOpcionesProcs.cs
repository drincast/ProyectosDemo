using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoMVC.Models
{
    public class ModelOpcionesProcs
    {
        public TipoBuscar objTipoBuscar { get; set; }

        public List<OpcionPorcs> lstObjOpciones { get; set; }

        public ModelOpcionesProcs()
        {
            objTipoBuscar = new TipoBuscar();
            lstObjOpciones = new List<OpcionPorcs>();
        }
    }
}