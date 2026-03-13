using DocumentFormat.OpenXml.Drawing.Charts;
using FLEXYGO.Objects.Settings;
using Services.Application;

namespace CommentM.Domain.Comment.AD
{
    public interface ICommentRepository: IRepositoryBase<Comments>
    {
        public OperationResult ChangeStatus(long id, int status);
       
        List<Comments> GetComment(int ownerid);
        List<Comments> CommentStatus(int status);
    }
}
