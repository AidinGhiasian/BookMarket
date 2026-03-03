using DocumentFormat.OpenXml.Drawing.Charts;
using FLEXYGO.Objects.Settings;
using Services.Application;

namespace CommentM.Domain.Comment.AD
{
    public interface ICommentRepository: IRepositoryBase<Comments>
    {
        public OperationResult Delete(long id);
        List<Comments> GetComment(int ownerid);
    }
}
