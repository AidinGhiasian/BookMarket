using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommentM.Domain.Comment.AD;

namespace CommentM.Application.Contracts
{
    public interface ICommentApplication
    {
        public void Create(CreateViewModel create);
        List<Comments> GetAll();
        List<CommentViewModel> GetComment(int recordId);
        void Delete(int id);
    }
}
