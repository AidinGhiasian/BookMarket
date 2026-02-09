using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Services
{
    public interface IFileUploader
    {
        public string UploadFileWithSignAsync(IFormFile file, string filePath, string sign);
        public string UploadFileAsync(IFormFile file, string filepath);
        public void DeleteFileAsync(string filePath);
    }
}
