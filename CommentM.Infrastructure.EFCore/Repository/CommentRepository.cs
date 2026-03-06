using CommentM.Domain.Comment.AD;
using CrystalDecisions.ReportAppServer;
using Services.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace CommentM.Infrastructure.EFCore.Repository
{
    public class CommentRepository : RepositoryBase<Comments>, ICommentRepository
    {
        private readonly CommentDbContext _commentDbContext;
        public CommentRepository(CommentDbContext commentdbcontext) : base(commentdbcontext)
        {
            _commentDbContext = commentdbcontext;
        }

        public List<Comments> CommentStatus(bool status)
        {
           return _commentDbContext.Comments.Where(x=>x.IsCanceled==status).ToList();
        }

        public OperationResult Delete(long id)
        {
            OperationResult result = new OperationResult();
            var comment = _commentDbContext.Comments.FirstOrDefault(x => x.Id == id);
            if (comment != null)
            {
                comment.ChangeStatus(true);
                result.IsSuccess();
                _commentDbContext.SaveChanges();
            }
            return result.Failed(ApplicationMessage.NotFund);
        }



        public List<Comments> GetComment(int ownerid)
        {
            var comments= _commentDbContext.Comments.Where(x => x.OwnerId == ownerid).ToList();
            return comments;
        }
    }
}
