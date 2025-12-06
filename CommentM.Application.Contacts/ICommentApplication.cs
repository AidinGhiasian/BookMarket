using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentM.Application.Contacts
{
    public interface ICommentApplication
    {
        public void create(CreateViewModel create);
        public void Edit(EditViewModel edit);
        public CommentViewModel GetBy(long id);
        public List<CommentViewModel> GetAll();
        public void Delete(long id);
    }
}
