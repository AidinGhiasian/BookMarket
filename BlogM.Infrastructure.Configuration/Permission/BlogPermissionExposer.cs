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
                        new PermissionDTO(20,"CreatePost"),
                        new PermissionDTO(21,"UpdatePost"),
                        new PermissionDTO(22,"ListPosts"),
                        new PermissionDTO(23,"SearchPosts"),
                    }
                },
                {
                    "BlogCategory",new List<PermissionDTO>
                    {
                        new PermissionDTO(30,"CreateBlogCategory"),
                        new PermissionDTO(31,"UpdateBlogCategory"),
                        new PermissionDTO(32,"ListBlogCategory"),
                        new PermissionDTO(33,"SearchBlogCategory"),
                    }
                },
                {
                    "Event",new List<PermissionDTO>
                    {
                        new PermissionDTO(40,"CreateEvent"),
                        new PermissionDTO(41,"UpdateEvent"),
                        new PermissionDTO(42,"ListEvent"),
                        new PermissionDTO(43,"SearchEvent"),
                    }
                }
            };
        }
    }
}
