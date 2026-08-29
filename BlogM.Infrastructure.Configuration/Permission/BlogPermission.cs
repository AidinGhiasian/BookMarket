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
        public const int ListPost = 200;
        public const int SearchPost = 201;
        public const int CreatePost = 202;
        public const int EditPost = 203;
        //BlogCategory
        public const int ListCategoryBlog = 204;
        public const int SearchCategoryBlog = 205;
        public const int CreateCategoryBlog = 206;
        public const int EditCategoryBlog = 207;
        //Event
        public const int ListEvent = 208;
        public const int SearchEvent = 209;
        public const int CreateEvent = 210;
        public const int EditEvent = 211;
        //+++
        public const int DeleteBlog = 212;
        public const int DeleteEvent = 213;
        public const int DeleteBlogCategory = 214;
    }
}
