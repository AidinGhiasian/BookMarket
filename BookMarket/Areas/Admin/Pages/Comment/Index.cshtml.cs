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
            if(isStatus==null||isStatus==0||isStatus==1)
            {
                isStatus = 1;
               Comments = _commentQueries.GetAll().Where(x=>x.IsStatus==1).ToList();//خوانده  نشده ها
            }else if (isStatus == 2)
            {
                Comments = _commentQueries.GetAll().Where(x => x.IsStatus == 2).ToList();//تایید شده ها
            }
            else if(isStatus == 3)
            {
                Comments = _commentQueries.GetAll().Where(x => x.IsStatus == 3).ToList();//رد شده ها
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
        public IActionResult OnGetDelete(int id)
        {
            if (id != null)
            {
                _commentQueries.Delete(id);
            }
            return Page();
        }
       

    }
}
