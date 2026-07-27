using CommentM.Application.Contracts;
using CommentM.Domain.Comment.AD;
using Services.Application;

namespace CommentM.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentrepository;
        public CommentApplication(ICommentRepository commentrepository)
        {
            _commentrepository = commentrepository;
        }

        public List<CommentViewModel> CommentStatus(int status, int ownerId)
            => _commentrepository.CommentStatus(status, ownerId).Select(Map).ToList();

        public List<CommentViewModel> CommentStatus(int status, int ownerId, int type)
            => _commentrepository.CommentStatus(status, ownerId, type).Select(Map).ToList();

        public OperationResult Create(CreateViewModel create)
        {
            var result = new OperationResult();
            if (string.IsNullOrWhiteSpace(create.FullName) || string.IsNullOrWhiteSpace(create.Message))
                return result.Failed("نام و متن نظر الزامی است.");

            var type = create.Type > 0 ? create.Type : 1; // default to book
            var cc = new Comments(create.FullName, create.Message, create.OwnerId, type);
            _commentrepository.Add(cc);
            _commentrepository.SaveChanges();
            return result.IsSuccess("نظر شما با موفقیت ثبت شد و پس از تایید نمایش داده می‌شود.");
        }

        public OperationResult ChangeStatus(long id, int status)
        {
            var comment = _commentrepository.GetByLongId(id);
            if (comment == null)
                return new OperationResult().Failed("نظر پیدا نشد.");

            _commentrepository.ChangeStatus(id, status);
            return new OperationResult().IsSuccess();
        }

        public List<CommentViewModel> GetAll()
            => _commentrepository.GetAll().Select(Map).ToList();

        public List<CommentViewModel> GetComment(int ownerId)
            => _commentrepository.GetComment(ownerId, (int)CommentStatus.Approved).Select(Map).ToList();

        public List<CommentViewModel> GetComment(int ownerId, int type)
            => _commentrepository.GetComment(ownerId, (int)CommentStatus.Approved, type).Select(Map).ToList();

        public OperationResult Delete(long id) => _commentrepository.Delete(id);

        public CommentViewModel Map(Comments c)
            => new()
            {
                Id = c.Id,
                FullName = c.FullName,
                Message = c.Message,
                CommentDateTime = c.CommentDatetime.ToFarsi(),
                OwnerId = c.OwnerId,
                IsStatus = c.IsStatus,
                Type = c.Type,
            };
    }
}
