using Blog.Domain.BlogCategoryAD;
using BlogM.Application.Contacts.BlogCategoryApplication;
using BookM.Domain.Book.AD;
using DocumentFormat.OpenXml.Spreadsheet;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            OperationResult result = new OperationResult();

            if (Exists(command.Name))
                return result.Failed(ApplicationMessage.Duplicate);

            var picturesName = _fileUploader.UploadNewSize(command.Picture, "BlogCategory", 720);

            var category = new BlogCategory(
                command.Name,
                picturesName,
                command.Slug,
                command.Description
            );

            _blogCategoryRepository.Add(category);
            _blogCategoryRepository.SaveChanges();
            return result.IsSuccess();
        }
        public bool Edit(EditBlogCategoryViewModel command)
        {
            var category = _blogCategoryRepository.GetById(command.Id);
            if (category == null)
                return false;


            var duplicate = _blogCategoryRepository.GetByName(command.Name);
            if (duplicate != null && duplicate.Id != command.Id)
                return false;


            var picturesName = command.PictureName;
            if (command.Picture != null)
            {
                _fileUploader.Delete(command.PictureName);
                picturesName = _fileUploader.UploadNewSize(command.Picture, "BlogCategory", 720);
            }

            category.Edit(
                command.Name,
                picturesName,
                command.Slug,
                command.Description,
                command.IsAvailable
            );

            _blogCategoryRepository.SaveChanges();
            return true;
        }
        public bool Exists(string name)
        {
            return _blogCategoryRepository.Exists(name);

        }

        public List<BlogCategoryViewModel> GetAll()
        {
            var list = _blogCategoryRepository.GetAll();

            return Maplist(list);
        }
        public BlogCategoryViewModel MapBlog(BlogCategory blogCategory)
        {
            if (blogCategory == null)
            {
                return null;
            }
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
        {
            return _blogCategoryRepository.GetAvailableCategories();
        }


        public BlogCategory? GetByName(string name)
        {
            return _blogCategoryRepository.GetByName(name);
        }

        public BlogCategory? GetBySlug(string slug)
        {
            return _blogCategoryRepository.GetBySlug(slug);
        }

        public BlogCategory? GetWithPostsBySlug(string slug)
        {
            return _blogCategoryRepository.GetWithPostsBySlug(slug);
        }
        public List<BlogCategoryViewModel> Maplist(List<BlogCategory>? cats)
        {
            var category = new List<BlogCategoryViewModel>();
            if (cats != null)
            {
                foreach (var cat in cats)
                {
                    category.Add(MapBlog(cat));
                }
            }

            return category;
        }

        public EditBlogCategoryViewModel GetDetail(int id)
        {
            var blogCategory = _blogCategoryRepository.GetById(id);
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
    }
}
