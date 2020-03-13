using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Routing;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;

namespace EShop.WEB.Filters
{
    public class ValidateFileAttribute: RequiredAttribute
    {
        //попытка создания фильтра проверки корректности загружаемого в бд файла 
        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;
            if(file == null)
            {
                return false;
            }
            //больше 1 мб?
            if(file.ContentLength > 1 * 1024 * 1024)
            {
                return false;
            }
            try
            {
                //файл формата JPEG?
                using(var img = Image.FromStream(file.InputStream))
                {
                    return img.RawFormat.Equals(ImageFormat.Jpeg);
                }
            }
            catch { }
            return false;
        }
    }
}