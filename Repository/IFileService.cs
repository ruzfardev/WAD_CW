using Microsoft.AspNetCore.Http;
using System;

namespace WADAPI.Repository
{
    public interface IFileService
    {
        public Tuple<int, string> SaveImage(IFormFile imageFile);
        public bool DeleteImage(string imageFileName);
    }
}
