using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoMVC.Models
{
    public class MDatos1
    {
        public string Tipo { get; set; }
        public string Codigo { get; set; }
        public int Orden { get; set; }
        public string Opcion { get; set; }
        public byte TipoOpcion { get; set; }
        public string Parametro { get; set; }
        public bool Inactivo { get; set; }
    }
}