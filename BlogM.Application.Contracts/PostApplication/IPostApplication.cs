using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.BlogAD;


namespace BlogM.Application.Contracts.PostApplication
{
    public interface IPostApplication
    {
      public void create(CreateViewModel create);
        PostViewModel? GetById(int id);
        public void Update(EditViewModel update);
        public void Delete(int id);
        public List<PostViewModel> GetAll();
        public EditViewModel GetDetailes(int id);
        public List<Posts> Search(string title);
    }
}
