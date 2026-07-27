using BlogM.Application.Contracts.PostApplication;
using BookM.ClientQueries.Model.Blog.Post;

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
            => _postApplication.GetAll().Select(Map).ToList();

        public List<PostQueryViewModel> GetAllBlogWithCategory(int? categoryId)
            => _postApplication.GetAll()
                .Where(x => x.BlogCategoryId == categoryId)
                .Select(Map)
                .ToList();

        public PostQueryViewModel? GetDetail(int id)
        {
            var post = _postApplication.GetById(id);
            return post == null ? null : Map(post);
        }

        public List<PostQueryViewModel> Search(string? title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return new List<PostQueryViewModel>();

            return _postApplication.Search(title)
                .Select(x => new PostQueryViewModel
                {
                    Id = x.Id,
                    Picture = x.Picture,
                    Title = x.Title,
                    ShortDescription = x.ShortDescription,
                    Description = x.Description,
                    PostTime = x.PostTime.ToFarsi(),
                    Category = x.BlogCategory?.Name ?? "",
                    IsAvailable = x.IsAvailable,
                    categoryId = x.BlogCategoryId,
                })
                .Where(x => x.Title.Contains(title))
                .ToList();
        }

        private static PostQueryViewModel Map(PostViewModel x) => new()
        {
            Id = x.Id,
            Picture = x.Picture,
            Title = x.Title,
            ShortDescription = x.ShortDescription,
            Description = x.Description,
            Category = x.Category ?? "",
            IsAvailable = x.IsAvailable,
            PostTime = x.PostTime,
            categoryId = x.BlogCategoryId,
        };
    }
}
