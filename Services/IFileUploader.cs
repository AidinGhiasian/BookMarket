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
         string UploadFileAsync(IFormFile file, string filepath);
        string UploadFileWithSignAsync(IFormFile file, string filePath, string sign);
        void DeleteFileAsync(string filePath);
       
    }
}
