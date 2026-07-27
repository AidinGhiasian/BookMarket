using Services.Application;

namespace BookM.ClientQueries.Model.Comment
{
    public interface ICommentQueries
    {
        List<CommentQueryViewModel> GetComment(int ownerId);
        List<CommentQueryViewModel> GetComment(int ownerId, int type);
        OperationResult ChangeStatus(long id, int status);
        OperationResult Delete(long id);
        List<CommentQueryViewModel> CommentStatus(int status, int ownerId);
        List<CommentQueryViewModel> CommentStatus(int status, int ownerId, int type);
        List<CommentQueryViewModel> GetAll();
    }
}
