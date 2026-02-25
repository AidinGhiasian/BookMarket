
using CommentM.Application.Contracts;
using Services.Application;

namespace BookM.ClientQueries.Model.Comment
{
    public interface ICommentQueries
    {
        List<CommentViewModel> GetAll();
        List<CommentViewModel> GetComment(int ownerId);
        OperationResult Delete(int id);
    }
}
