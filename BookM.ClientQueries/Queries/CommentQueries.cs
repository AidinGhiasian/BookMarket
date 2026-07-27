using BookM.ClientQueries.Model.Comment;
using CommentM.Application.Contracts;
using Services.Application;

namespace BookM.ClientQueries.Queries
{
    public class CommentQueries : ICommentQueries
    {
        private readonly ICommentApplication _commentApplication;

        public CommentQueries(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }

        public OperationResult ChangeStatus(long id, int status)
            => _commentApplication.ChangeStatus(id, status);

        public OperationResult Delete(long id) => _commentApplication.Delete(id);

        public List<CommentQueryViewModel> GetComment(int ownerId)
            => _commentApplication.GetComment(ownerId).Select(Map).ToList();

        public List<CommentQueryViewModel> GetComment(int ownerId, int type)
            => _commentApplication.GetComment(ownerId, type).Select(Map).ToList();

        public List<CommentQueryViewModel> CommentStatus(int status, int ownerId)
            => _commentApplication.CommentStatus(status, ownerId).Select(Map).ToList();

        public List<CommentQueryViewModel> CommentStatus(int status, int ownerId, int type)
            => _commentApplication.CommentStatus(status, ownerId, type).Select(Map).ToList();

        public List<CommentQueryViewModel> GetAll()
            => _commentApplication.GetAll().Select(Map).ToList();

        private static CommentQueryViewModel Map(CommentViewModel comment) => new()
        {
            Id = comment.Id,
            FullName = comment.FullName,
            Message = comment.Message,
            CommentDateTime = comment.CommentDateTime,
            OwnerId = comment.OwnerId,
            IsStatus = comment.IsStatus,
            Type = comment.Type,
        };
    }
}
