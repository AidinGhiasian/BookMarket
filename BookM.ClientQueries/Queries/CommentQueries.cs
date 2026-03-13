using BookM.ClientQueries.Blog.Post;
using BookM.ClientQueries.Model.Comment;
using CommentM.Application.Contracts;
using CommentM.Domain.Comment.AD;
using DocumentFormat.OpenXml.Spreadsheet;
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


        public OperationResult ChangeStatus(long id,int status)
        {
            return _commentApplication.ChangeStatus(id,status);
        }
       

        public CommentQueryViewModel Map(CommentViewModel comment)
        {
            return new CommentQueryViewModel
            {
                Id = comment.Id,
                FullName = comment.FullName,
                Message = comment.Message,
                CommentDateTime = comment.CommentDateTime,
                OwnerId = comment.OwnerId,
            };
        }
        public List<CommentQueryViewModel> GetComment(int recordId)
        {
            var comment = _commentApplication.GetComment(recordId);
            var newList = new List<CommentQueryViewModel>();
            foreach (var item in comment)
            {
                newList.Add(Map(item));
            }
            return newList;
        }

        public List<CommentQueryViewModel> GetAll()
        {
            return _commentApplication.GetAll().Select(Map).ToList();
        }

        public List<CommentQueryViewModel> CommentStatus(int status)
        {
            return _commentApplication.CommentStatus(status).Select(Map).ToList();
        }
    }
}
