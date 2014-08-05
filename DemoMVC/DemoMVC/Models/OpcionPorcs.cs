using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoMVC.Models
{
    public class OpcionPorcs
    {
        public int numero { get; set; }
        public string tipo { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public bool inactivo { get; set; }
        public string codigoGeneral { get; set; }
        public int orden { get; set; }
        public Int16 tipoOpcion { get; set; }
        public string parametro { get; set; }
    }
}