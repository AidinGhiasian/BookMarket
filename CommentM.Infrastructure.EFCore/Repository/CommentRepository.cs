using CommentM.Domain.Comment.AD;
using Microsoft.EntityFrameworkCore;
using Services.Application;

namespace CommentM.Infrastructure.EFCore.Repository
{
    public class CommentRepository : RepositoryBase<Comments>, ICommentRepository
    {
        private readonly CommentDbContext _commentDbContext;
        public CommentRepository(CommentDbContext commentdbcontext) : base(commentdbcontext)
        {
            _commentDbContext = commentdbcontext;
        }

        public List<Comments> CommentStatus(int? status, int? ownerid, int? type = null)
        {
            IQueryable<Comments> q = _commentDbContext.Comments;
            if (status.HasValue)
                q = q.Where(x => x.IsStatus == status.Value);
            if (ownerid.HasValue)
                q = q.Where(x => x.OwnerId == ownerid.Value);
            if (type.HasValue)
                q = q.Where(x => x.Type == type.Value);
            return q.ToList();
        }

        public OperationResult ChangeStatus(long id, int status)
        {
            var comment = _commentDbContext.Comments.FirstOrDefault(x => x.Id == id);
            if (comment == null)
                return new OperationResult().Failed(ApplicationMessage.NotFound);

            comment.ChangeStatus(status);
            _commentDbContext.SaveChanges();
            return new OperationResult().IsSuccess();
        }

        public List<Comments> GetComment(int ownerid, int? status, int? type = null)
        {
            IQueryable<Comments> q = _commentDbContext.Comments.Where(x => x.OwnerId == ownerid);
            if (status.HasValue)
                q = q.Where(x => x.IsStatus == status.Value);
            if (type.HasValue)
                q = q.Where(x => x.Type == type.Value);
            return q.ToList();
        }

        public OperationResult Delete(long id)
        {
            var comment = _commentDbContext.Comments.FirstOrDefault(x => x.Id == id);
            if (comment == null)
                return new OperationResult().Failed(ApplicationMessage.NotFound);

            _commentDbContext.Comments.Remove(comment);
            _commentDbContext.SaveChanges();
            return new OperationResult().IsSuccess();
        }
    }
}
