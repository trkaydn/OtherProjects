using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using YuzTanima.Models;

namespace YuzTanima.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                // Resmi PNG formatında kaydet
                var filePath = Path.Combine(Server.MapPath("~/Images"), Path.GetFileNameWithoutExtension(file.FileName) + ".png");
                using (var bitmap = new System.Drawing.Bitmap(file.InputStream))
                {
                    if (bitmap.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png))
                    {
                        bitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    else
                    {
                        var newImage = new System.Drawing.Bitmap(bitmap);
                        newImage.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                    }
                }

                // Yüklenen resmi işleme sok
                using (var image = new Image<Bgr, byte>(filePath))
                {
                    // Yüzleri tespit et
                    var faceCascade = new CascadeClassifier(Server.MapPath("~/Content/haarcascade_frontalface_default.xml"));
                    var faces = faceCascade.DetectMultiScale(image, 1.1, 10, System.Drawing.Size.Empty);
                    var yuzlerVarMi = faces.Length > 0;

                    // Yüzlerin varlığına göre sonucu döndür
                    var model = new YuzTanimaModel
                    {
                        YuzlerVarMi = yuzlerVarMi
                    };

                    return View("Index", model);
                }
            }

            return View();
        }

    }
}
