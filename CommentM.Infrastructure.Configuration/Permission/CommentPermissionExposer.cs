using Services.Infrastructure;

namespace CommentMInfrastructureConfiguration.Permission
{
    public class CommentPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDTO>> Expose()
        {
            return new Dictionary<string, List<PermissionDTO>>
            {
                {
                    "نظرات",new List<PermissionDTO>
                    {
                        new PermissionDTO(CommentPermission.ListComment,"لیست نظرات"),
                        new PermissionDTO(CommentPermission.SearchComment,"جستجوی نظرات"),
                        new PermissionDTO(CommentPermission.CreateComment,"اظهار نظر کردن"),
                        new PermissionDTO(CommentPermission.EditComment,"ویرایش نظرات"),
                        new PermissionDTO(CommentPermission.DeleteComment,"حذف نظرات"),
                        new PermissionDTO(CommentPermission.ApprovingCommnet,"تایید کردن نظرات"),
                        new PermissionDTO(CommentPermission.AnswerCommnet,"پاسخ دادن به نظرات"),
                    }
                }
            };
        }
    }
}
