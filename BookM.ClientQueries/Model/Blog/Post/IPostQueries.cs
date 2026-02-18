using BookM.ClientQueries.Blog.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookM.ClientQueries.Model.Blog.Post
{
    public interface IPostQueries
    {
        public List<PostQueryViewModel> GetAll();
       public PostQueryViewModel GetDetail (int id);
    }
}
