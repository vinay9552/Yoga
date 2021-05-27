using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Yoga.Controllers.Yoga
{
    public class YogaController : Controller
    {
        // GET: Yoga
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult YogaDetails()
        {
            return View();
        }
        
    }
}