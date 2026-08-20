using BlogMInfrastructureConfiguration.Permissions;
using Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentMInfrastructureConfiguration.Permission
{
    public class CommentPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDTO>> Expose()
        {
            return new Dictionary<string, List<PermissionDTO>>
            {
                {
                    "Comment",new List<PermissionDTO>
                    {
                        new PermissionDTO(CommentPermission.ListComment,"لیست نظرات"),
                        new PermissionDTO(CommentPermission.SearchComment,"جستجوی نظرات"),
                        new PermissionDTO(CommentPermission.CreateComment,"اظهار نظر کردن"),
                        new PermissionDTO(CommentPermission.EditComment,"ویرایش نظرات"),
                    }
                }
            };
        }
    }
}
