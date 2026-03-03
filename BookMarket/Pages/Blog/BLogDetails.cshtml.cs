
using BookM.ClientQueries.Blog.Post;
using BookM.ClientQueries.Model.Blog.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CommentM.Application.Contracts;
using BookM.ClientQueries.Model.Comment;
using Services.Application;
namespace BookMarket.Pages.Blog
{
    public class BLogDetailsModel : PageModel
    {
        private readonly IPostQueries _postQueries;
        private readonly ICommentQueries _commentQueries;
        private readonly ICommentApplication _commentApplication;
        public BLogDetailsModel(IPostQueries postQueries, ICommentQueries commentQueries, ICommentApplication commentApplication)
        {
            _postQueries = postQueries;
            _commentQueries = commentQueries;
            _commentApplication = commentApplication;
        }
        public PostQueryViewModel Post { get; set; }
        public List<BookM.ClientQueries.Model.Comment.CommentViewModel> CommentList { get; set; }
        public void OnGet(int id)
        {
            Post = _postQueries.GetDetail(id);
            CommentList = _commentQueries.GetComment(id);
            
            
        }
        public IActionResult OnPost(CreateViewModel command)
        {
            var resault = _commentQueries.Create(command);
            return Redirect("./BlogDetails");
        }

    }
}
