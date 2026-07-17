
using CommentM.Application.Contracts;
using CommentM.Domain.Comment.AD;
using Services.Application;

namespace BookM.ClientQueries.Model.Comment
{
    public interface ICommentQueries
    {
        List<CommentQueryViewModel> GetComment(int ownerId);
        OperationResult ChangeStatus(long id,int status);
        OperationResult Delete(long id);
        public List<CommentQueryViewModel> CommentStatus(int status, int ownerId);
        CommentQueryViewModel Map(CommentM.Application.Contracts.CommentViewModel comment);
        List<CommentQueryViewModel> GetAll();
    }
}
