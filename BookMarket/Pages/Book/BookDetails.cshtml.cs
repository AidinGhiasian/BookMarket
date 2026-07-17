using BookM.ClientQueries.Model.Book.Books;
using BookM.ClientQueries.Model.Comment;
using CommentM.Application;
using CommentM.Application.Contracts;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Pages.Book
{
    public class BookDetailsModel : PageModel
    {
        private readonly IBookQueries _bookQueries;
        private readonly ICommentApplication _commentApplication;
        private readonly ICommentQueries _commentQueries;
        public BookDetailsModel(IBookQueries bookQueries, ICommentApplication commentApplication, ICommentQueries commentQueries)
        {
            _bookQueries = bookQueries;
            _commentApplication = commentApplication;
            _commentQueries = commentQueries;
        }
        public BookQueryViewModel Book { get; set; }
        public List<CommentQueryViewModel>? CommentList { get; set; }
        public List<BookQueryViewModel> BookWithCategory { get; set; }
        public void OnGet(int id)
        {
            Book = _bookQueries.GetDetailInfo(id);
            CommentList = _commentQueries.CommentStatus(2,id);
            BookWithCategory = _bookQueries.GetAllBookWithCategory(Book.CategoryId);
        }

        public IActionResult OnPost(CreateViewModel command, int Id)
        {
            command.OwnerId = Id;
            var resault = _commentApplication.Create(command);
            return RedirectToPage("./BookDetails", new { id = Id });
        }
    }
}
