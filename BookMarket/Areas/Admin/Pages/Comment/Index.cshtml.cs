using BookM.ClientQueries.Model.Comment;
using CommentM.Domain.Comment.AD;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Pages.Comment
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly ICommentQueries _commentQueries;
        public IndexModel(ICommentQueries commentQueries)
        {
            _commentQueries = commentQueries;
        }
        public List<CommentQueryViewModel> Comments { get; set; } = new();

        public void OnGet(int? isStatus)
        {
            int status = isStatus ?? (int)CommentStatus.Pending;
            Comments = _commentQueries.GetAll().Where(x => x.IsStatus == status).ToList();
        }

        public IActionResult OnPostChangeStatus(int isStatus, long id)
        {
            _commentQueries.ChangeStatus(id, isStatus);
            return RedirectToPage(new { isStatus });
        }

        public IActionResult OnPostDelete(long id, int? isStatus)
        {
            _commentQueries.Delete(id);
            return RedirectToPage(new { isStatus });
        }
    }
}
