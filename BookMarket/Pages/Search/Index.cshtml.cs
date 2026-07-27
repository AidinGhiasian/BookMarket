using BookM.ClientQueries.Model.Blog.Post;
using BookM.ClientQueries.Model.Book.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Pages.Search
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly IBookQueries _books;
        private readonly IPostQueries _posts;

        public IndexModel(IBookQueries books, IPostQueries posts)
        {
            _books = books;
            _posts = posts;
        }

        public List<BookQueryViewModel> Books { get; set; } = new();
        public List<PostQueryViewModel> Posts { get; set; } = new();

        public void OnGet(string? title)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                Books = _books.Search(title);
                Posts = _posts.Search(title);
            }
        }
    }
}
