using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoMVC;
using DemoMVC.Controllers;

namespace DemoMVC.Tests.Controllers
{
    [TestClass]
    public class MapsControllerTest
    {
        [TestMethod]
        public void ViewMaps()
        {            
            MapsController controller = new MapsController();

            ViewResult result = controller.ViewMaps() as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}
