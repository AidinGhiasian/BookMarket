using BookM.ClientQueries.Model.Comment;
using BookM.ClientQueries.Queries;
using CommentM.Domain.Comment.AD;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICommentQueries _commentQueries;
        public IndexModel(ICommentQueries commentQueries)
        {
            _commentQueries = commentQueries;
        }
        public List<CommentQueryViewModel> Comments { get; set; } = new();

        public void OnGet()
        {
            Comments = _commentQueries.GetAll()
                .Where(x => x.IsStatus == (int)CommentStatus.Pending)
                .Take(4).ToList();
        }

        public IActionResult OnPostApprove(long id)
        {
            _commentQueries.ChangeStatus(id, (int)CommentStatus.Approved);
            return RedirectToPage();
        }

        public IActionResult OnPostReject(long id)
        {
            _commentQueries.ChangeStatus(id, (int)CommentStatus.Rejected);
            return RedirectToPage();
        }
    }
}

