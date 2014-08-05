using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoMVC.Models
{
    public class Personas
    {
        public string saludo { get; set; }
        public string nombre { get; set; }

        public Personas()
        {
            this.saludo = "Hola ";
            this.nombre = string.Empty;
        }
    }
}