using DocumentFormat.OpenXml.Drawing.Charts;
using FLEXYGO.Objects.Settings;
using Services.Application;

namespace CommentM.Domain.Comment.AD
{
    public interface ICommentRepository: IRepositoryBase<Comments>
    {
        public OperationResult ChangeStatus(long id, int status);
        public OperationResult Delete(long id);
        public List<Comments> GetComment(int ownerid, int status);
        public List<Comments> CommentStatus(int status, int ownerid);

    }
}
