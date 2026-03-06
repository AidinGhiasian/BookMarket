using Blog.Domain.BlogCategoryAD;
using BlogM.Application.Contracts.BlogCategoryApplication;
using BookM.ClientQueries.Blog.Categores;
using BookM.ClientQueries.Model.Blog.Categores;
using Services.Application;
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
                list.Add(Map(item));
            }
            return list;
        }

        public BlogCategoryQueryViewModel GetPostsWithCategory()
        {
            var category = _blogcategoryApplication.GetPostsWithCategory();

            return new BlogCategoryQueryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Slug = category.Slug,
                Description = category.Description,
                Picture = category.Picture,
                CreationDate = category.CreationDate.ToFarsi(),
                IsAvailable = category.IsAvailable,
                PostCount = category.Posts.Count,
            };
        }

        public List<BlogCategoryQueryViewModel> GetPostWithCategories()
        {
            var categories = _blogcategoryApplication.GetPostWithCategories();
            var listcategory = new List<BlogCategoryQueryViewModel>();
            foreach (var category in categories)
            {
                if (category.Posts != null)
                {
                    listcategory.Add(new BlogCategoryQueryViewModel
                    {
                        Id = category.Id,
                        Name = category.Name,
                        Slug = category.Slug,
                        Description = category.Description,
                        Picture = category.Picture,
                        CreationDate = category.CreationDate.ToFarsi(),
                        IsAvailable = category.IsAvailable,
                        PostCount = category.Posts.Count(),

                    });
                }
                else
                {
                    listcategory.Add(new BlogCategoryQueryViewModel
                    {
                        Id = category.Id,
                        Name = category.Name,
                        Slug = category.Slug,
                        Description = category.Description,
                        Picture = category.Picture,
                        CreationDate = category.CreationDate.ToFarsi(),
                        IsAvailable = category.IsAvailable,
                        PostCount = 0

                    });
                }

            }
            return listcategory;
        }

        public BlogCategoryQueryViewModel Map(BlogCategoryViewModel item)
        {
            return new BlogCategoryQueryViewModel
            {
                Id = item.Id,
                Name = item.Name,
                Slug = item.Slug,
                Description = item.Description,
                Picture = item.Picture,
                CreationDate = item.CreationDate,
                IsAvailable = item.IsAvailable,

            };
        }

    }
}
