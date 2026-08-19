using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMInfrastructureConfiguration.Permission
{
    public class BlogPermission
    {
        //Post
        public const int ListPost = 17;
        public const int SearchPost = 18;
        public const int CreatePost = 19;
        public const int EditPost = 20;
        //BlogCategory
        public const int ListCategoryBlog = 21;
        public const int SearchCategoryBlog = 22;
        public const int CreateCategoryBlog = 23;
        public const int EditCategoryBlog = 24;
        //Event
        public const int ListEvent = 25;
        public const int SearchEvent = 26;
        public const int CreateEvent = 27;
        public const int EditEvent = 28;
    }
}
