using BlogMInfrastructureConfiguration.Permissions;
using Services.Infrastructure;

namespace BlogMInfrastructureConfiguration.Permission
{
    public class BlogPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDTO>> Expose()
        {

            return new Dictionary<string, List<PermissionDTO>>
            {
                {
                    "Post",new List<PermissionDTO>
                    {
                        new PermissionDTO(BlogPermission.CreatePost,"ساخت پست"),
                        new PermissionDTO(BlogPermission.EditPost,"ویرایش پست"),
                        new PermissionDTO(BlogPermission.ListPost,"لیست پست ها"),
                        new PermissionDTO(BlogPermission.SearchPost,"جستجوی پست ها"),
                    }
                },
                {
                    "BlogCategory",new List<PermissionDTO>
                    {
                        new PermissionDTO(BlogPermission.CreateCategoryBlog,"ساخت دسته بندی مقاله"),
                        new PermissionDTO(BlogPermission.EditCategoryBlog,"ویرایش دسته بندی مقاله"),
                        new PermissionDTO(BlogPermission.SearchCategoryBlog,"جستجوی دسته بندی مقاله"),
                        new PermissionDTO(BlogPermission.ListCategoryBlog,"لیست مقالات"),
                    }
                },
                {
                    "Event",new List<PermissionDTO>
                    {
                        new PermissionDTO(BlogPermission.CreateEvent,"ساخت رویداد"),
                        new PermissionDTO(BlogPermission.EditEvent,"ویرایش رویداد"),
                        new PermissionDTO(BlogPermission.ListEvent,"لیست رویداد ها"),
                        new PermissionDTO(BlogPermission.SearchEvent,"جستجوی رویداد ها"),
                    }
                }
            };
        }
    }
}
