using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.BlogAD;
using Book.Infrastructure.EFCore;
using Services;
using Services.Model;

namespace BlogM.Infrastructure.EFCore.Repository
{
    public class BlogRepository : RepositoryBase<Posts>, IBlogRepository
    {
        private readonly BlogDbContext _blogdbcontext;
        private readonly IFileUploader _fileuploader;
        public BlogRepository(BlogDbContext blogdbcontext,IFileUploader fileUploader):base(blogdbcontext)
        {
            _blogdbcontext = blogdbcontext;
            _fileuploader = fileUploader;
        }
        public void Create(Posts posts)
        {
            _blogdbcontext.Posts.Add(posts);
            _blogdbcontext.SaveChanges();
        }

        public void Delete(int id)
        {
          var DB = _blogdbcontext.Posts.Find(id);
            if (DB != null)
            { 
               _blogdbcontext.Posts.Remove(DB);
                _blogdbcontext.SaveChanges();
            }
        }

        public List<Posts> GetAll()
        {
            return _blogdbcontext.Posts.ToList();
        }

        public Posts Getby(string Title)
        {
            return _blogdbcontext.Posts.FirstOrDefault(x => x.Title == Title);
        }

        public Posts? GetById(int id)
        {
            return _blogdbcontext.Posts.FirstOrDefault(x => x.Id == id);
        }


        void IBlogRepository.Updateby(Posts posts)
        {
            var EB = _blogdbcontext.Posts.FirstOrDefault(x => x.Id == posts.Id);
            if (EB != null)
            {
                EB.Edit(posts.Picture, posts.Title, posts.ShortDescription
                    , posts.Description, posts.IsAvailable);
                _blogdbcontext.SaveChanges();
            }
        }
    }
}
