using BookM.ClientQueries.Model.Book.Books;
using BookM.ClientQueries.Model.Comment;
using CommentM.Application.Contracts;
using CommentM.Domain.Comment.AD;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Pages.Book
{
    [AllowAnonymous]
    public class BookDetailsModel : PageModel
    {
        private readonly IBookQueries _bookQueries;
        private readonly ICommentApplication _commentApplication;
        private readonly ICommentQueries _commentQueries;

        public BookDetailsModel(IBookQueries bookQueries,
            ICommentApplication commentApplication,
            ICommentQueries commentQueries)
        {
            _bookQueries = bookQueries;
            _commentApplication = commentApplication;
            _commentQueries = commentQueries;
        }

        public BookQueryViewModel? Book { get; set; }
        public List<CommentQueryViewModel>? CommentList { get; set; }
        public List<BookQueryViewModel>? BookWithCategory { get; set; }

        public IActionResult OnGet(int id)
        {
            Book = _bookQueries.GetDetailInfo(id);
            if (Book == null)
                return RedirectToPage("/Book/Index");

            CommentList = _commentQueries.CommentStatus((int)CommentStatus.Approved, id, (int)CommentType.Book);
            BookWithCategory = _bookQueries.GetAllBookWithCategory(Book.CategoryId);
            return Page();
        }

        public IActionResult OnPost(CreateViewModel command, int Id)
        {
            if (!ModelState.IsValid)
            {
                return OnGet(Id);
            }
            command.OwnerId = Id;
            command.Type = (int)CommentType.Book;
            _commentApplication.Create(command);
            TempData["Success"] = "نظر شما با موفقیت ثبت شد و پس از تایید نمایش داده می‌شود.";
            return RedirectToPage("./BookDetails", new { id = Id });
        }
    }
}
