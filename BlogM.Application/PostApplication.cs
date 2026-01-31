using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.BlogAD;
using BlogM.Application.Contacts.PostApplication;
using Services;


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
            var path = create.Picture;
            var pictureName=_fileUploader.UploadFileAsync(create.FileName, path);
            var post = new Posts(pictureName, create.Title, create.ShortDescription, create.Description);
            _blogRepository.Create(post);
        }
        public void Delete(int id)
        {
            _blogRepository.Delete(id);
        }

        public List<PostViewModel> GetAll()
        {
           var posts = _blogRepository.GetAll();
            var list=new List<PostViewModel>();
            foreach (var post in posts) 
            {
                list.Add(map(post));
            }
            return list;

        }

        public PostViewModel? GetById(int id)
        {
          var post= _blogRepository.GetById(id);
            return map(post);
        }

        public void Update(EditViewModel update)
        {
            var post = _blogRepository.GetById(update.Id);

            var pictureName =update.Picture;

            if (update.FileName != null)
            {
                _fileUploader.DeleteFileAsync(update.Picture);
                var path = "picture";
                pictureName = _fileUploader.UploadFileAsync(update.FileName, path);
            }

            post.Edit(pictureName, update.Title, update.ShortDescription,
                update.Description, update.IsAvailable);

            _blogRepository.Updateby(post);

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
                PostTime = posts.PostTime,
                UpdatedTime = posts.UpdatedTime,
            };
            
        }
      

    }

}
