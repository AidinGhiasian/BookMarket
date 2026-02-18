using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.BlogCategoryAD
{
    public interface IBlogCategoryRepository : IRepositoryBase<BlogCategory>
    {
        BlogCategory? GetByName(string name);
        BlogCategory? GetBySlug(string slug);
        List<BlogCategory> GetAvailableCategories();
        BlogCategory? GetWithPostsBySlug(string slug);
        bool Exists(string name);

    }
}
