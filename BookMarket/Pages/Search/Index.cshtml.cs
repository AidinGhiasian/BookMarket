using BookM.ClientQueries.Blog.Post;
using BookM.ClientQueries.Model.Blog.Post;
using BookM.ClientQueries.Model.Book.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Pages.Search
{
    public class IndexModel : PageModel
    {
        private readonly IBookQueries _books;
        private readonly IPostQueries _Posts;


        public IndexModel(IBookQueries Books,IPostQueries Posts)
        {
            _books=Books;
            _Posts=Posts;
        }

        public List<BookQueryViewModel> Books { get; set; }
        public List<PostQueryViewModel> Posts { get; set; }

        public void OnGet(string title)
        {
            if (title!=null)
            {
                Books=_books.Search(title);
                Posts = _Posts.Search(title);
            }
            

        }
    }
}
