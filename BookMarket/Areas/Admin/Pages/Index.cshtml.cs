using BookM.ClientQueries.Model.Comment;
using BookM.ClientQueries.Queries;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Application;

namespace BookMarket.Areas.Admin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICommentQueries _commentQueries;
        public IndexModel(ICommentQueries commentQueries)
        {
            _commentQueries = commentQueries;
        }
        public List<CommentQueryViewModel> Comments { get; set; }
        public void OnGet(long? id, int? status)
        {
            Comments = _commentQueries.CommentStatus(1).Take(4).ToList();
            if (id!=null && status!=null)
            {
                long Id=id.Value;
                int Status=status.Value;
                _commentQueries.ChangeStatus(Id, Status);

            }
        }
      

    }

}
