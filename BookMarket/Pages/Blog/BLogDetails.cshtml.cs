
using BookM.ClientQueries.Blog.Categores;
using BookM.ClientQueries.Blog.Post;
using BookM.ClientQueries.Model.Blog.Categores;
using BookM.ClientQueries.Model.Blog.Post;
using BookM.ClientQueries.Model.Comment;
using BookM.ClientQueries.Queries;
using CommentM.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Application;
namespace BookMarket.Pages.Blog
{
    public class BLogDetailsModel : PageModel
    {
        private readonly IPostQueries _postQueries;
        private readonly ICommentQueries _commentQueries;
        private readonly ICommentApplication _commentApplication;
        private readonly IBlogCategoryQueries _blogCategoryQueries;
       
        public BLogDetailsModel(IPostQueries postQueries
            , ICommentQueries commentQueries
            , ICommentApplication commentApplication, IBlogCategoryQueries blogCategoryQueries)
        {
            _postQueries = postQueries;
            _commentQueries = commentQueries;
            _commentApplication = commentApplication;
            _blogCategoryQueries = blogCategoryQueries;
        }
        public PostQueryViewModel Post { get; set; }
        public List<PostQueryViewModel> Posts { get; set; }
        public List<BookM.ClientQueries.Model.Comment.CommentQueryViewModel> CommentList { get; set; }
        public List<BlogCategoryQueryViewModel> Categories { get; set; }
        public List<PostQueryViewModel> postCategory { get; set; }
        public void OnGet(int id)
        {
            Post = _postQueries.GetDetail(id);
            CommentList = _commentQueries.CommentStatus(2);
            Categories = _blogCategoryQueries.GetPostWithCategories();
            Posts = _postQueries.GetAll();
            postCategory = _postQueries.GetAllBlogWithCategory(Post.categoryId);

        }
        public IActionResult OnPost(CreateViewModel command)
        {
            
            var resault = _commentApplication.Create(command);
            return RedirectToPage("./BlogDetails", new { id =command.OwnerId });
        }

    }
}
