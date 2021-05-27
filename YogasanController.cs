using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoga.Models;
using System.IO;

namespace Yoga.Admin.Yogasan
{
    public class YogasanController : Controller
    {
        // GET: Yogasan
        public ActionResult Index()
        {
            return View();
        }

        

        public ActionResult SaveYogasan(YogasanModel model)
        {
            try
            {
                HttpPostedFileBase fb = null;
                HttpPostedFileBase fb1 = null;
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    fb = Request.Files[0];
                    fb1 = Request.Files[1];

                }
                return Json(new { model = new YogasanModel().SaveYogasan(fb,fb1, model) }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {

                {
                    return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
                }

            }

        }

        public ActionResult DisplayYogasanDisplay()
        {
            try
            {
                return Json(new { model = (new YogasanModel().DisplayYogasanDisplay()) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}