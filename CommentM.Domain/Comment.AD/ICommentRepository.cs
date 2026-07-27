using Services.Application;

namespace CommentM.Domain.Comment.AD
{
    public interface ICommentRepository : IRepositoryBase<Comments>
    {
        OperationResult ChangeStatus(long id, int status);
        OperationResult Delete(long id);
        List<Comments> GetComment(int ownerid, int? status = null, int? type = null);
        List<Comments> CommentStatus(int? status, int? ownerid, int? type = null);
    }
}
