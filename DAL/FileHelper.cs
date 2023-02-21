using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Threading.Tasks;
using System;

namespace WAD_CW.DAL
{
    public class FileHelper
    {
        public static async Task<string> SaveImage(IFormFile file)
        {
            if (file is null)
                throw new Exception("File is empty!");

            string folder = $"Images/recipes/";
            var path = Path.Combine("wwwroot", folder);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);
            var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            await File.WriteAllBytesAsync(Path.Combine(path, fileName), ms.ToArray());
            return folder + fileName;
        }
    }
}
