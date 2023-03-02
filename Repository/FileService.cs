using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WADAPI.Repository
{
    public class FileService : IFileService
    {
        private IWebHostEnvironment _environment;
        public FileService(IWebHostEnvironment env)
        {
            this._environment = env;
        }
        // Delete image
        public bool DeleteImage(string imageFileName)
        {
            throw new NotImplementedException();
        }

        // Save image file
        public Tuple<int, string> SaveImage(IFormFile imageFile)
        {
            try
            {

                string folder = "Images/recipes/";
                var path = Path.Combine("wwwroot", folder);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                var ext = Path.GetExtension(imageFile.FileName);
                var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };
                if (!allowedExtensions.Contains(ext))
                {
                    string msg = $@"Only {string.Join(",", allowedExtensions)} extensions are allowed";
                    return new Tuple<int, string>(0, msg);
                }
                var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(imageFile.FileName);
                var ms = new MemoryStream();
                imageFile.CopyToAsync(ms);
                File.WriteAllBytesAsync(Path.Combine(path, fileName), ms.ToArray());
                return new Tuple<int, string>(1, fileName);
            }
            catch (Exception ex)
            {
                return new Tuple<int, string>(0, "Error has occured");
            }
        }
    }
}
