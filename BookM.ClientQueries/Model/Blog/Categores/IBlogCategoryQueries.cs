using System.Collections.Generic;

namespace BookM.ClientQueries.Model.Blog.Categores
{
    public interface IBlogCategoryQueries
    {
        List<BlogCategoryQueryViewModel> GetAll();
        List<BlogCategoryQueryViewModel> GetPostWithCategories();
    }
}
