using Services.Application;
using System.Collections.Generic;

namespace Blog.Domain.BlogCategoryAD
{
    public interface IBlogCategoryRepository : IRepositoryBase<BlogCategory>
    {
        BlogCategory? GetByName(string name);
        BlogCategory? GetBySlug(string slug);
        List<BlogCategory> GetAvailableCategories();
        BlogCategory? GetWithPostsBySlug(string slug);
        bool Exists(string name);
        List<BlogCategory> GetPostWithCategories();
    }
}
