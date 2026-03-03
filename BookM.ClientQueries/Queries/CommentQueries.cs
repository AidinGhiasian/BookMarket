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

        public OperationResult Create(CreateViewModel command)
        {
            return _commentApplication.Create(command);
        }

        public OperationResult Delete(int id)
        {
            return _commentApplication.Delete(id);
        }

       
        public Model.Comment.CommentViewModel Map(CommentM.Application.Contracts.CommentViewModel comment)
        {
            return new Model.Comment.CommentViewModel
            {
                Id = comment.Id,
                FullName = comment.FullName,
                Message = comment.Message,
                CommentDateTime = comment.CommentDateTime,
                OwnerId = comment.OwnerId,
            };
        }
        public List<Model.Comment.CommentViewModel> GetComment(int recordId)
        {
            var comment= _commentApplication.GetComment(recordId);
            var newList = new List<Model.Comment.CommentViewModel>();
            foreach (var item in comment)
            {
                newList.Add(Map(item));
            }
            return newList;
        }
      
    }
}
