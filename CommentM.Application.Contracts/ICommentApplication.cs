using Services.Application;

namespace CommentM.Application.Contracts
{
    public interface ICommentApplication
    {
        OperationResult Create(CreateViewModel create);
        List<CommentViewModel> GetComment(int ownerId);
        List<CommentViewModel> GetComment(int ownerId, int type);
        List<CommentViewModel> CommentStatus(int status, int ownerId);
        List<CommentViewModel> CommentStatus(int status, int ownerId, int type);
        List<CommentViewModel> GetAll();
        OperationResult ChangeStatus(long id, int status);
        OperationResult Delete(long id);
    }
}
