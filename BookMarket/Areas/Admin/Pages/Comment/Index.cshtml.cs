using BookM.ClientQueries.Model.Comment;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Application;

namespace BookMarket.Areas.Admin.Pages.Comment
{
    public class IndexModel : PageModel
    {
        private readonly ICommentQueries _commentQueries;
        public IndexModel(ICommentQueries commentQueries)
        {
            _commentQueries = commentQueries;
        }
        public List<CommentQueryViewModel> Comments { get; set; }
        public void OnGet(int isStatus)
        {
            if(isStatus == 0)
            {
               Comments = _commentQueries.CommentStatus(1).ToList();
            }else if (isStatus == 1)
            {
                Comments = _commentQueries.CommentStatus(2).ToList();
            }
            else if(isStatus == 2)
            {
                Comments = _commentQueries.CommentStatus(3).ToList();
            }
        }
        public IActionResult OnGetChangeStatus(int? isStatus,int? id)
        {
            if (id != null && isStatus != null)
            {
                long Id = id.Value;
                int Status = isStatus.Value;
                _commentQueries.ChangeStatus(Id, Status);
                return Redirect("./Comment/Index");
            }
            return Redirect("./Comment/Index");
        }
       
       

    }
}
