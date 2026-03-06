using Blog.Domain.BlogCategoryAD;
using Services.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogM.Application.Contracts.BlogCategoryApplication
{
    public interface IBlogCategoryApplication
    {
        public OperationResult Create(CreateBlogCategoryViewModel command);
        public bool Edit(EditBlogCategoryViewModel command);
        BlogCategory? GetByName(string name);
        BlogCategory? GetBySlug(string slug);
        List<BlogCategory> GetAvailableCategories();
        List<BlogCategoryViewModel> GetAll();
        BlogCategory? GetWithPostsBySlug(string slug);
        public EditBlogCategoryViewModel GetDetail(int id);
        bool Exists(string name);
        BlogCategory GetPostsWithCategory();
        public List<BlogCategory> GetPostWithCategories();
    }
}
