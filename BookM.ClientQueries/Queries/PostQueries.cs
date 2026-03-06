using Blog.Domain.BlogAD;
using BlogM.Application.Contracts.PostApplication;
using BookM.ClientQueries.Blog.Post;
using BookM.ClientQueries.Model.Blog.Post;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages;

namespace BookM.ClientQueries.Queries
{
    public class PostQueries : IPostQueries
    {
        private readonly IPostApplication _postApplication;

        public PostQueries(IPostApplication postApplication)
        {
            _postApplication = postApplication;
        }
        public List<PostQueryViewModel> GetAll()
        {
            return _postApplication.GetAll()
               .Select(x => new PostQueryViewModel
               {
                   Id = x.Id,
                   Picture = x.Picture,
                   Title = x.Title,
                   ShortDescription = x.ShortDescription,
                   Description = x.Description,
                   Category = x.Category,
                   IsAvailable = x.IsAvailable
                   
               })
               .ToList();
        }

       

        public List<PostQueryViewModel> GetAllBlogWithCategory(int? categoryId)
        {
            return _postApplication.GetAll()
               .Select(x => new PostQueryViewModel
               {
                   Id = x.Id,
                   Picture = x.Picture,
                   Title = x.Title,
                   ShortDescription = x.ShortDescription,
                   Description = x.Description,
                   Category = x.Category,
                   IsAvailable = x.IsAvailable,
                   categoryId= x.BlogCategoryId,
                   

               }).Where(x => x.categoryId == categoryId)
               .ToList();
        }
        public PostQueryViewModel GetDetail(int id)
        {
            var post = _postApplication.GetById(id);

            if (post == null)
                return null;

            return new PostQueryViewModel
            {
                Id = post.Id,
                Picture = post.Picture,
                Title = post.Title,
                ShortDescription = post.ShortDescription,
                Description = post.Description,
                PostTime = post.PostTime,
                Category = post.Category,
                IsAvailable = post.IsAvailable,
                categoryId=post.BlogCategoryId

            };
        }
    }
}
