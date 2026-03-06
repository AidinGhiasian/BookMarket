using BookM.ClientQueries.Model.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Application;

namespace BookMarket.Areas.Admin.Pages.Comment
{
    public class IndexModel : PageModel
    {
        private readonly ICommentQueries _commnetQueries;
        public IndexModel(ICommentQueries commentQueries)
        {
            _commnetQueries = commentQueries;
        }
        public List<CommentViewModel> Comments { get; set; }
        public void OnGet(int isStatus=1)
        {
            if(isStatus == 1)
            {
                Comments = _commnetQueries.CommentStatus(true);
            }else if(isStatus == 2)
            {
                Comments = _commnetQueries.CommentStatus(false);
            }
        }
        public IActionResult OnGetDelete(long id)
        {
            _commnetQueries.Delete(id);
            TempData["Success"] = "دیدگاه با موفقیت حذف شد.";
           return RedirectToPage("./Index");
        }

    }
}
