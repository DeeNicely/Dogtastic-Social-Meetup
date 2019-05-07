using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dogtastic.Controllers
{
    public class DogtasticController : Controller
    {
        // GET: Dogtastic
        public ActionResult Index()
        {
            return View();
        }
    }
}