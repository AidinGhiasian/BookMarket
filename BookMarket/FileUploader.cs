using Microsoft.AspNetCore.Hosting;
using Services.Application;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace BookMarket
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        private static readonly string[] AllowedImageExtensions = { ".jpg", ".jpeg", ".png", ".webp" };
        private const long MaxFileSizeBytes = 5 * 1024 * 1024; // 5 MB
        private const string PicturesFolder = "Pictures";

        public FileUploader(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string Upload(IFormFile file, string path)
        {
            if (file == null || file.Length == 0)
                return "";

            ValidateFile(file);

            var safeFolder = SanitizeFolder(path);
            var directoryPath = Path.Combine(_webHostEnvironment.WebRootPath, PicturesFolder, safeFolder);
            Directory.CreateDirectory(directoryPath);

            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            var fileName = $"{DateTime.Now.ToFileName()}-{Guid.NewGuid():N}{ext}";
            var filepath = Path.Combine(directoryPath, fileName);

            using var output = File.Create(filepath);
            file.CopyTo(output);

            return $"{safeFolder}/{fileName}";
        }

        public string UploadNewSize(IFormFile file, string path, int width)
        {
            if (file == null || file.Length == 0)
                return "";

            ValidateFile(file);

            var safeFolder = SanitizeFolder(path);
            var sizeFolder = width.ToString();
            var directoryPath = Path.Combine(_webHostEnvironment.WebRootPath, PicturesFolder, safeFolder, sizeFolder);
            Directory.CreateDirectory(directoryPath);

            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            var fileName = $"{DateTime.Now.ToFileName()}-{Guid.NewGuid():N}{ext}";
            var filepath = Path.Combine(directoryPath, fileName);

            using (var img = Image.Load(file.OpenReadStream()))
            {
                img.Mutate(r => r.Resize(new ResizeOptions
                {
                    Size = new Size(width, 0),
                    Mode = ResizeMode.Max
                }));
                img.Save(filepath);
            }

            return $"{safeFolder}/{sizeFolder}/{fileName}";
        }

        public string UploadNewSizeFromWightAndHeight(IFormFile file, string path, int width, int height)
        {
            if (file == null || file.Length == 0)
                return "";

            ValidateFile(file);

            var safeFolder = SanitizeFolder(path);
            var sizeFolder = width.ToString();
            var directoryPath = Path.Combine(_webHostEnvironment.WebRootPath, PicturesFolder, safeFolder, sizeFolder);
            Directory.CreateDirectory(directoryPath);

            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            var fileName = $"{DateTime.Now.ToFileName()}-{Guid.NewGuid():N}{ext}";
            var filepath = Path.Combine(directoryPath, fileName);

            using (var img = Image.Load(file.OpenReadStream()))
            {
                img.Mutate(r => r.Resize(new ResizeOptions
                {
                    Size = new Size(width, height),
                    Mode = ResizeMode.Crop
                }));
                img.Save(filepath);
            }

            return $"{safeFolder}/{sizeFolder}/{fileName}";
        }

        public void Delete(string pictureName)
        {
            if (string.IsNullOrWhiteSpace(pictureName))
                return;

            var picturesRoot = Path.GetFullPath(Path.Combine(_webHostEnvironment.WebRootPath, PicturesFolder));
            var fullPath = Path.GetFullPath(Path.Combine(picturesRoot, pictureName));

            // guard against path traversal: only allow deleting inside wwwroot/Pictures
            if (!fullPath.StartsWith(picturesRoot, StringComparison.OrdinalIgnoreCase))
                return;

            if (File.Exists(fullPath))
                File.Delete(fullPath);

            // try deleting the resized variant (720) if present
            var name = Path.GetFileName(fullPath);
            var dir = Path.GetDirectoryName(fullPath);
            var sizedDir = Path.Combine(dir ?? picturesRoot, "720");
            var sizedFile = Path.Combine(sizedDir, name);
            if (File.Exists(sizedFile))
                File.Delete(sizedFile);
        }

        private static void ValidateFile(IFormFile file)
        {
            if (file == null) throw new ArgumentNullException(nameof(file));
            if (file.Length > MaxFileSizeBytes)
                throw new InvalidOperationException($"حجم فایل بیش از حد مجاز ({MaxFileSizeBytes / 1024 / 1024} مگابایت) است.");

            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (string.IsNullOrEmpty(ext) || !AllowedImageExtensions.Contains(ext))
                throw new InvalidOperationException("نوع فایل مجاز نیست. فقط jpg, jpeg, png, webp پذیرفته می‌شود.");
        }

        private static string SanitizeFolder(string folder)
        {
            if (string.IsNullOrWhiteSpace(folder)) return "Misc";
            // Only take the leaf folder name (prevents ../../)
            var leaf = Path.GetFileName(folder.Replace("\\", "/").TrimEnd('/').TrimEnd('\\'));
            return string.IsNullOrWhiteSpace(leaf) ? "Misc" : leaf;
        }
    }
}
