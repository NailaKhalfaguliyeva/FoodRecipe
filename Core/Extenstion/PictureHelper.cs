using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extenstion
{
    public static class PictureHelper
    {
        public static string UploadImage(this IFormFile formFile, string webRootPath)
        {
            var path = "/Images/" + Guid.NewGuid().ToString() + formFile.FileName;
            using (FileStream fileStream = new FileStream(webRootPath + path, FileMode.Create))
            {
                formFile.CopyTo(fileStream);
            }
            return path;
        }
    }
}
