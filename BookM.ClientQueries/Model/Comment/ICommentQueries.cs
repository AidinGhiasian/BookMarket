
using CommentM.Application.Contracts;
using CommentM.Domain.Comment.AD;
using Services.Application;

namespace BookM.ClientQueries.Model.Comment
{
    public interface ICommentQueries
    {
        public OperationResult Create(CreateViewModel command);
       
        List<CommentViewModel> GetComment(int ownerId);
        OperationResult Delete(int id);
        CommentViewModel Map(CommentM.Application.Contracts.CommentViewModel comment);
    }
}
