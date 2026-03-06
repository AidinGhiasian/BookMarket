using CommentM.Domain.Comment.AD;
using Services.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentM.Application.Contracts
{
    public interface ICommentApplication
    {
        public OperationResult Create(CreateViewModel create);
        public List<CommentViewModel> GetComment(int ownerId);
        public List<CommentViewModel> CommentStatus(bool status);
        public List<CommentViewModel> GetAll();
        public OperationResult Delete(long id);
    }
}
