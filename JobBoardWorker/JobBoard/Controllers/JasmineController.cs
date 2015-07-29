using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobBoard.Controllers
{
    public class JasmineController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Views/Jasmine/SpecRunner.cshtml");
        }
    }
}
