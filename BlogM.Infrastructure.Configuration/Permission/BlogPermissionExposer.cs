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
                    "پست",new List<PermissionDTO>
                    {
                        new PermissionDTO(BlogPermission.CreatePost,"ساخت پست"),
                        new PermissionDTO(BlogPermission.EditPost,"ویرایش پست"),
                        new PermissionDTO(BlogPermission.ListPost,"لیست پست ها"),
                        new PermissionDTO(BlogPermission.SearchPost,"جستجوی پست ها"),
                        new PermissionDTO(BlogPermission.DeleteBlog,"حذف پست ها"),
                    }
                },
                {
                    "دسته بندی مقالات",new List<PermissionDTO>
                    {
                        new PermissionDTO(BlogPermission.CreateCategoryBlog,"ساخت دسته بندی مقاله"),
                        new PermissionDTO(BlogPermission.EditCategoryBlog,"ویرایش دسته بندی مقاله"),
                        new PermissionDTO(BlogPermission.SearchCategoryBlog,"جستجوی دسته بندی مقاله"),
                        new PermissionDTO(BlogPermission.ListCategoryBlog,"لیست مقالات"),
                        new PermissionDTO(BlogPermission.DeleteBlogCategory,"حذف دسته بندی مقالات"),
                    }
                },
                {
                    "رویداد",new List<PermissionDTO>
                    {
                        new PermissionDTO(BlogPermission.CreateEvent,"ساخت رویداد"),
                        new PermissionDTO(BlogPermission.EditEvent,"ویرایش رویداد"),
                        new PermissionDTO(BlogPermission.ListEvent,"لیست رویداد ها"),
                        new PermissionDTO(BlogPermission.SearchEvent,"جستجوی رویداد ها"),
                        new PermissionDTO(BlogPermission.DeleteEvent,"حذف رویداد ها"),
                    }
                }
            };
        }
    }
}
