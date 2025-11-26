using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Services.Model
{
    public class FileUploader : IFileUploader
    {
        public void DeleteFileAsync(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException("کاربر عزیز مسیری که انتخاب کرده اید معتبر نمی باشد...");

            if (File.Exists(filePath))

                File.Delete(filePath);


        }

        public string UploadFileAsync(IFormFile file, string filepath)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentNullException("...کاربر عزیز لطفا فایلی را انتخاب کنید");

            if (!Directory.Exists(filepath))
                Directory.CreateDirectory(filepath);

            var fullpath = Path.Combine(filepath, file.FileName);


            using (var stream = new FileStream(fullpath, FileMode.Create))
            {
                file.CopyToAsync(stream);
            }
            return fullpath;
        }

        public string UploadFileWithSignAsync(IFormFile file, string filePath, string sign)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentNullException("کاربر عزیز مسیری که انتخاب کرده اید معتبر نمی باشد...");

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);


            var extension = Path.GetExtension(file.FileName);

            var fileNameWithoutExt = Path.GetFileNameWithoutExtension(file.FileName);

            var NewFileName = $"{fileNameWithoutExt}_{sign}{extension}";

            var fullpath = Path.Combine(filePath, NewFileName);


            using (var stream = new FileStream(fullpath, FileMode.Create))
            {
                file.CopyToAsync(stream);
            }
            return fullpath;

        }
    }
}





