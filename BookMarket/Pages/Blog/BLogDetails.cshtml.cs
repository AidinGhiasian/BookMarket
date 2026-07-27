using BookM.ClientQueries.Model.Blog.Categores;
using BookM.ClientQueries.Model.Blog.Post;
using BookM.ClientQueries.Model.Comment;
using CommentM.Application.Contracts;
using CommentM.Domain.Comment.AD;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Pages.Blog
{
    [AllowAnonymous]
    public class BLogDetailsModel : PageModel
    {
        private readonly IPostQueries _postQueries;
        private readonly ICommentQueries _commentQueries;
        private readonly ICommentApplication _commentApplication;
        private readonly IBlogCategoryQueries _blogCategoryQueries;

        public BLogDetailsModel(IPostQueries postQueries,
            ICommentQueries commentQueries,
            ICommentApplication commentApplication,
            IBlogCategoryQueries blogCategoryQueries)
        {
            _postQueries = postQueries;
            _commentQueries = commentQueries;
            _commentApplication = commentApplication;
            _blogCategoryQueries = blogCategoryQueries;
        }

        public PostQueryViewModel? Post { get; set; }
        public List<PostQueryViewModel>? Posts { get; set; }
        public List<CommentQueryViewModel>? CommentList { get; set; }
        public List<BlogCategoryQueryViewModel>? Categories { get; set; }
        public List<PostQueryViewModel>? PostCategory { get; set; }

        public IActionResult OnGet(int id)
        {
            Post = _postQueries.GetDetail(id);
            if (Post == null)
                return RedirectToPage("./Index");

            CommentList = _commentQueries.CommentStatus((int)CommentStatus.Approved, id, (int)CommentType.Blog);
            Categories = _blogCategoryQueries.GetPostWithCategories();
            Posts = _postQueries.GetAll();
            PostCategory = _postQueries.GetAllBlogWithCategory(Post.categoryId);
            return Page();
        }

        public IActionResult OnPost(CreateViewModel command, int id)
        {
            if (!ModelState.IsValid)
                return OnGet(id);

            command.OwnerId = id;
            command.Type = (int)CommentType.Blog;
            _commentApplication.Create(command);
            TempData["Success"] = "نظر شما با موفقیت ثبت شد و پس از تایید نمایش داده می‌شود.";
            return RedirectToPage("./BlogDetails", new { id });
        }
    }
}
