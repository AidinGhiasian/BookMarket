using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommentM.Domain.Comment.AD;

namespace CommentM.Application.Contacts
{
    public interface ICommentApplication
    {
        public void create(CreateViewModel create);
        void Edit(EditViewModel edit);
        Comments GetById(long id);
        List<CommentViewModel> GetComment();
        void Delete(long id);
    }
}
