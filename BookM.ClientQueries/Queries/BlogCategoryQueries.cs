using Blog.Domain.BlogCategoryAD;
using BlogM.Application.Contracts.BlogCategoryApplication;
using BookM.ClientQueries.Blog.Categores;
using BookM.ClientQueries.Model.Blog.Categores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        {
            var category = _blogcategoryApplication.GetAll();
            var list = new List<BlogCategoryQueryViewModel>();

            foreach (var item in category)
            {
                list.Add(new BlogCategoryQueryViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Slug = item.Slug,
                    Description = item.Description,
                    Picture = item.Picture,
                    CreationDate = item.CreationDate,
                    IsAvailable = item.IsAvailable,
                });
            }
            return list;
        }
    }
}
