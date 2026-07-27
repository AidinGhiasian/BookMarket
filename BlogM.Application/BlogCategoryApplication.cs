using Blog.Domain.BlogCategoryAD;
using BlogM.Application.Contracts.BlogCategoryApplication;
using Services.Application;
using System.Collections.Generic;
using System.Linq;

namespace BlogM.Application
{
    public class BlogCategoryApplication : IBlogCategoryApplication
    {
        private readonly IBlogCategoryRepository _blogCategoryRepository;
        private readonly IFileUploader _fileUploader;

        public BlogCategoryApplication(IBlogCategoryRepository blogCategoryRepository, IFileUploader fileUploader)
        {
            _blogCategoryRepository = blogCategoryRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateBlogCategoryViewModel command)
        {
            var result = new OperationResult();
            if (Exists(command.Name))
                return result.Failed(ApplicationMessage.Duplicate);

            var picturesName = "";
            if (command.Picture != null)
                picturesName = _fileUploader.UploadNewSize(command.Picture, "BlogCategory", 720);

            var category = new BlogCategory(command.Name, picturesName, command.Slug, command.Description);
            _blogCategoryRepository.Add(category);
            _blogCategoryRepository.SaveChanges();
            return result.IsSuccess();
        }

        public bool Edit(EditBlogCategoryViewModel command)
        {
            var category = _blogCategoryRepository.GetById(command.Id);
            if (category == null) return false;

            var duplicate = _blogCategoryRepository.GetByName(command.Name);
            if (duplicate != null && duplicate.Id != command.Id)
                return false;

            var picturesName = command.PictureName ?? "";
            if (command.Picture != null)
            {
                if (!string.IsNullOrWhiteSpace(command.PictureName))
                    _fileUploader.Delete(command.PictureName);
                picturesName = _fileUploader.UploadNewSize(command.Picture, "BlogCategory", 720);
            }

            category.Edit(command.Name, picturesName, command.Slug, command.Description, command.IsAvailable);
            _blogCategoryRepository.SaveChanges();
            return true;
        }

        public bool Exists(string name) => _blogCategoryRepository.Exists(name);

        public List<BlogCategoryViewModel> GetAll()
            => _blogCategoryRepository.GetAll().Select(MapBlog).Where(x => x != null).Select(x => x!).ToList();

        private static BlogCategoryViewModel? MapBlog(BlogCategory? blogCategory)
        {
            if (blogCategory == null) return null;
            return new BlogCategoryViewModel
            {
                Id = blogCategory.Id,
                Name = blogCategory.Name,
                Slug = blogCategory.Slug,
                Description = blogCategory.Description,
                Picture = blogCategory.Picture,
                CreationDate = blogCategory.CreationDate.ToFarsi(),
                IsAvailable = blogCategory.IsAvailable,
            };
        }

        public List<BlogCategory> GetAvailableCategories()
            => _blogCategoryRepository.GetAvailableCategories();

        public BlogCategory? GetByName(string name) => _blogCategoryRepository.GetByName(name);
        public BlogCategory? GetBySlug(string slug) => _blogCategoryRepository.GetBySlug(slug);
        public BlogCategory? GetWithPostsBySlug(string slug) => _blogCategoryRepository.GetWithPostsBySlug(slug);

        public EditBlogCategoryViewModel GetDetail(int id)
        {
            var blogCategory = _blogCategoryRepository.GetById(id);
            if (blogCategory == null) throw new System.InvalidOperationException(ApplicationMessage.NotFound);
            return new EditBlogCategoryViewModel
            {
                Id = blogCategory.Id,
                Name = blogCategory.Name,
                Slug = blogCategory.Slug,
                Description = blogCategory.Description,
                PictureName = blogCategory.Picture,
                IsAvailable = blogCategory.IsAvailable,
            };
        }

        public List<BlogCategory> GetPostWithCategories() => _blogCategoryRepository.GetPostWithCategories();
    }
}
