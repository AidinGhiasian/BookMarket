using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.BlogAD
{
    public interface IBlogRepository
    {
        public void Create(Posts posts);
        public Posts? GetById(int id);
        public void Updateby(Posts posts);
        public Posts Getby(string Title);
        public void Delete(int id);
        public List<Posts> GetAll();
    }
}
