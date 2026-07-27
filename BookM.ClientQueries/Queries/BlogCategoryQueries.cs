using BlogM.Application.Contracts.BlogCategoryApplication;
using BookM.ClientQueries.Model.Blog.Categores;
using System.Collections.Generic;
using System.Linq;

namespace BookM.ClientQueries.Queries
{
    public class BlogCategoryQueries : IBlogCategoryQueries
    {
        private readonly IBlogCategoryApplication _blogcategoryApplication;

        public BlogCategoryQueries(IBlogCategoryApplication blogcategoryApplication)
        {
            _blogcategoryApplication = blogcategoryApplication;
        }

        public List<BlogCategoryQueryViewModel> GetAll()
            => _blogcategoryApplication.GetAll().Select(item => new BlogCategoryQueryViewModel
            {
                Id = item.Id,
                Name = item.Name,
                Slug = item.Slug,
                Description = item.Description,
                Picture = item.Picture,
                CreationDate = item.CreationDate,
                IsAvailable = item.IsAvailable,
            }).ToList();

        public List<BlogCategoryQueryViewModel> GetPostWithCategories()
        {
            var categories = _blogcategoryApplication.GetPostWithCategories();
            return categories.Select(category => new BlogCategoryQueryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Slug = category.Slug,
                Description = category.Description,
                Picture = category.Picture,
                CreationDate = category.CreationDate.ToFarsi(),
                IsAvailable = category.IsAvailable,
                PostCount = category.Posts?.Count() ?? 0,
            }).ToList();
        }
    }
}
