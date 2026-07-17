using Blog.Domain.BlogAD;
using BookM.Domain.Book.AD;
using CommentM.Domain.Comment.AD;
using CrystalDecisions.ReportAppServer;
using DocumentFormat.OpenXml.Office2010.Excel;
using FLEXYGO.GoogleResourceTypes;
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

        public List<Comments> CommentStatus(int status,int ownerid)
        {

            if (status!=null)
            {
                if (ownerid!=null)
                {
                    var comments = _commentDbContext.Comments.Where(x => x.IsStatus == status && x.OwnerId == ownerid).ToList();
                    return comments;
                }
            }
            return _commentDbContext.Comments.Where(x => x.IsStatus == status && x.OwnerId == ownerid).ToList();
        }

        public OperationResult ChangeStatus(long id, int status)
        {
            OperationResult result = new OperationResult();
            var comment = _commentDbContext.Comments.FirstOrDefault(x => x.Id == id);
            if (comment != null)
            {
                comment.ChangeStatus(status);
                result.IsSuccess();
                _commentDbContext.SaveChanges();
            }
                return result.Failed(ApplicationMessage.NotFund);
        }



        public List<Comments> GetComment(int ownerid,int status)
        {
           
            var comments = _commentDbContext.Comments.Where(x => x.OwnerId == ownerid).ToList();
           
            return comments;

        }

        public OperationResult Delete(long id)
        {
            OperationResult result = new OperationResult();
            var comment = _commentDbContext.Comments.FirstOrDefault(x => x.Id == id);
            if (comment != null)
            {

                _commentDbContext.Comments.Remove(comment);
                _commentDbContext.SaveChanges();
                return result.IsSuccess();
                
            }
             return result.Failed(ApplicationMessage.NotFund);
        }

    }
}
