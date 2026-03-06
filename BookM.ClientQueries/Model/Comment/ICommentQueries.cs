
using CommentM.Application.Contracts;
using CommentM.Domain.Comment.AD;
using Services.Application;

namespace BookM.ClientQueries.Model.Comment
{
    public interface ICommentQueries
    {
        List<CommentViewModel> GetComment(int ownerId);
        OperationResult Delete(long id);
        public List<CommentViewModel> CommentStatus(bool status);
        CommentViewModel Map(CommentM.Application.Contracts.CommentViewModel comment);
        List<CommentViewModel> GetAll();
    }
}
