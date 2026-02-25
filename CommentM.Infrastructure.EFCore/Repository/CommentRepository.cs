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


        public OperationResult Delete(int id)
        {
            OperationResult result = new OperationResult();
            var comment = _commentDbContext.Comments.FirstOrDefault(x => x.Id == id);
            if (comment != null)
            {
                result.IsSuccess();
            }
            return result.Failed(ApplicationMessage.NotFund);
        }



        public List<Comments> GetComment(int ownerid)
        {
            return _commentDbContext.Comments.Where(x => x.OwnerId == ownerid).ToList();
        }
    }
}
