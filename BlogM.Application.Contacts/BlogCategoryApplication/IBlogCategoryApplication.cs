using Blog.Domain.BlogCategoryAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogM.Application.Contacts.BlogCategoryApplication
{
    public interface IBlogCategoryApplication
    {
        public bool Create(CreateBlogCategoryViewModel command);
        public bool Edit(EditBlogCategoryViewModel command);
        BlogCategory? GetByName(string name);
        BlogCategory? GetBySlug(string slug);
        List<BlogCategory> GetAvailableCategories();
        List<BlogCategoryViewModel> GetAll();
        BlogCategory? GetWithPostsBySlug(string slug);
        bool Exists(string name);
    }
}
