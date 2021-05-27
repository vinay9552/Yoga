using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Yoga.Data;
using System.IO;

namespace Yoga.Admin.Yogasan
{
    public class YogasanModel
    {

        public int AsanId { get; set; }
        public string AsanName { get; set; }
        public string Description { get; set; }
        public string Steps { get; set; }
        public string Photo1 { get; set; }
        public string Photo2 { get; set; }
        public string Benefits { get; set; }
        public string Precaution { get; set; }
        public string CreatedBy { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }

        public string SaveYogasan(HttpPostedFileBase fb, HttpPostedFileBase fb1, YogasanModel model)
        {
            string message = "";
            YogaNerPEntities db = new YogaNerPEntities();
            string filePath = "";
            string fileName = "";
            string sysFileName = "";


            if (fb != null && fb.ContentLength > 0)
            {
                filePath = HttpContext.Current.Server.MapPath("~/Admin/Content/imgs/");
                DirectoryInfo di = new DirectoryInfo(filePath);
                if (!string.IsNullOrWhiteSpace(fb.FileName))
                {
                    di.Create();
                }
                fileName = fb.FileName;
                sysFileName = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(fb.FileName);
                fb.SaveAs(filePath + "//" + sysFileName);
                if (!string.IsNullOrWhiteSpace(fb.FileName))
                {
                    string aafileName = HttpContext.Current.Server.MapPath("~/Admin/Content/imgs/") + "/" + sysFileName;
                }
            }
            if (fb1 != null && fb1.ContentLength > 0)
            {
                fileName = fb1.FileName;
                sysFileName = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(fb1.FileName);
                fb1.SaveAs(filePath + "//" + sysFileName);
                if (!string.IsNullOrWhiteSpace(fb1.FileName))
                {
                    string afileName = HttpContext.Current.Server.MapPath("~/Admin/Content/imgs/") + "/" + sysFileName;

                }
            }
            var saveYogasan = new tblAsan()
            {

                AsanName = model.AsanName,
                Description = model.Description,
                Steps = model.Steps,
                Photo1 = sysFileName,
                Photo2 = sysFileName,
                Benefits = model.Benefits,
                Precaution = model.Precaution,
                CreatedBy = model.CreatedBy,
                Category = model.Category,
                Type = model.Type,


            };
            db.tblAsans.Add(saveYogasan);
            db.SaveChanges();

            return message;
        }

        public List<YogasanModel> DisplayYogasanDisplay()
        {
            YogaNerPEntities Db = new YogaNerPEntities();
            List<YogasanModel> lstDisplayYogasanDisplay = new List<YogasanModel>();
            var AddDisplayYogasanDisplay = Db.tblAsans.ToList();
            if (AddDisplayYogasanDisplay != null)
            {
                foreach (var DisplayYogasanDisplay in AddDisplayYogasanDisplay)
                {
                    lstDisplayYogasanDisplay.Add(new YogasanModel()
                    {

                        AsanId = DisplayYogasanDisplay.AsanId,
                        AsanName = DisplayYogasanDisplay.AsanName,
                        Description = DisplayYogasanDisplay.Description,
                        Steps = DisplayYogasanDisplay.Steps,
                        Photo1 = DisplayYogasanDisplay.Photo1,
                        Photo2 = DisplayYogasanDisplay.Photo2,
                        Benefits = DisplayYogasanDisplay.Benefits,
                        Precaution = DisplayYogasanDisplay.Precaution,
                        CreatedBy = DisplayYogasanDisplay.CreatedBy,
                        Category = DisplayYogasanDisplay.Category,
                        Type = DisplayYogasanDisplay.Type,


                    });

                }


            }
            return lstDisplayYogasanDisplay;
        }


    }


}

        



