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

        public bool Create(CreateBlogCategoryViewModel command)
        {
            if (Exists(command.Name))
                return false;
            var picturesName = _fileUploader.UploadNewSize(command.Picture, command.Name, 720);

            var category = new BlogCategory(
                command.Name,
                picturesName,
                command.Slug,
                command.Description
            );

            _blogCategoryRepository.Add(category);
            return true;
        }
        public bool Edit(EditBlogCategoryViewModel command)
        {
            var category = _blogCategoryRepository.GetById(command.Id);
            if (category == null)
                return false;


            var duplicate = _blogCategoryRepository.GetByName(command.Name);
            if (duplicate != null && duplicate.Id != command.Id)
                return false;


            var picturesName =command.PictureName;
            if (command.Picture != null)
            {
                _fileUploader.Delete(command.PictureName);
                 picturesName = _fileUploader.UploadNewSize(command.Picture, command.Name, 720);
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
            return new List<BlogCategoryViewModel>();
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
            //if (cats != null)
            //{
            //    foreach (var cat in cats)
            //    {
            //        category.Add(Map(cat));
            //    }
            //}

            return category;
        }
    }
}
