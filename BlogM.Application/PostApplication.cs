using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.BlogAD;
using BlogM.Application.Contracts.PostApplication;
using Services.Application;


namespace BlogM.Application
{
    public class PostApplication : IPostApplication
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IFileUploader _fileUploader;
        public PostApplication(IBlogRepository blogRepository, IFileUploader fileUploader)
        {
            _blogRepository = blogRepository;
            _fileUploader = fileUploader;
        }
        public void create(CreateViewModel create)
        {
            var path = "Post";
            var pictureName = _fileUploader.UploadNewSize(create.FileName, path, 720);
            var post = new Posts(pictureName, create.Title, create.ShortDescription, create.Description, create.BlogCategoryId);
            _blogRepository.Create(post);
        }
        public void Delete(int id)
        {
            _blogRepository.Delete(id);
        }

        public List<PostViewModel> GetAll()
        {
            return _blogRepository.GetAll().Select(map).ToList();


        }

        public PostViewModel? GetById(int id)
        {
            var post = _blogRepository.GetById(id);
            return map(post);
        }

        public EditViewModel GetDetailes(int id)
        {
            var posts = _blogRepository.GetById(id);
            return new EditViewModel
            {
                Id = posts.Id,
                Picture = posts.Picture,
                Title = posts.Title,
                ShortDescription = posts.ShortDescription,
                Description = posts.Description,
                IsAvailable = posts.IsAvailable,
                BlogCategoryId = posts.BlogCategoryId,

            };
        }

        public void Update(EditViewModel update)
        {
            var post = _blogRepository.GetById(update.Id);

            var pictureName = update.Picture;

            if (update.FileName != null)
            {
                _fileUploader.Delete(update.Picture);
                var path = "Post";
                pictureName = _fileUploader.UploadNewSize(update.FileName, path, 720);
            }

            post.Edit(pictureName, update.Title, update.ShortDescription,
                update.Description, update.IsAvailable, update.BlogCategoryId);


            _blogRepository.SaveChanges();


        }


        private PostViewModel map(Posts posts)
        {
            return new PostViewModel
            {
                Id = posts.Id,
                Picture = posts.Picture,
                Title = posts.Title,
                ShortDescription = posts.ShortDescription,
                Description = posts.Description,
                IsAvailable = posts.IsAvailable,
                PostTime = posts.PostTime.ToFarsi(),
                UpdatedTime = posts.UpdatedTime,
                Category = posts.BlogCategory.Name,
            };

        }


    }

}
