
using BookM.ClientQueries.Blog.Categores;

namespace BookM.ClientQueries.Model.Blog.Categores
{
    public interface IBlogCategoryQueries
    {
        public List<BlogCategoryQueryViewModel> GetAll();
    }
}
