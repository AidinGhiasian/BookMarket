using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.BlogAD;
using BlogM.Infrastructure.EFCore;

namespace Blog.Infrastructure.EFCore.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDBContext _dbcontext;
        public BlogRepository(BlogDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void Create(Posts posts)
        {
            var b = _dbcontext.Posts.Add(posts);
            _dbcontext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbcontext.Posts.Remove(_dbcontext.Posts.Find(id));
            _dbcontext.SaveChanges();
        }

        public List<Posts> GetAll()
        {
            return _dbcontext.Posts.ToList();
        }

        public Posts Getby(string Title)
        {
            var b = _dbcontext.Posts.FirstOrDefault(p => p.BookTitle == Title);
            if (b != null)
            {
                return b;
            }
            return null;
        }


        public Posts? GetById(int id)
        {
            var b = _dbcontext.Posts.FirstOrDefault(p => p.Id == id);
            if (b != null)
            {
                return b;
            }
            return null;
        }

        public void Updateby(Posts posts)
        {
            var b = _dbcontext.Posts.Update(posts);
        }
    }
}
