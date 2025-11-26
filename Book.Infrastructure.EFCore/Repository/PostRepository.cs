using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.BlogAD;
using Book.Infrastructure.EFCore;
using Services;

namespace Blog.Infrastructure.EFCore.Repository
{
    public class PostRepository : IBlogRepository
    {
        private readonly BlogDbContext _blogdbcontext;
        private readonly IFileUploader _fileuploader;
        public PostRepository(BlogDbContext blogdbcontext,IFileUploader fileUploader)
        {
            _blogdbcontext = blogdbcontext;
            _fileuploader = fileUploader;
        }
        public void Create(Posts posts)
        {
            var CB = _blogdbcontext.Posts.Add(posts);
            _blogdbcontext.SaveChanges();
        }

        public void Delete(int id)
        {
          var DB = _blogdbcontext.Posts.Find(id);
            if (DB != null)
            { 
               _blogdbcontext.Posts.Remove(DB);
            }
        }

        public List<Posts> GetAll()
        {
            return _blogdbcontext.Posts.ToList();

        }

        public Posts Getby(string Title)
        {
            throw new NotImplementedException();
        }

        public Posts? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Updateby(Posts posts)
        {
            throw new NotImplementedException();
        }
    }
}
