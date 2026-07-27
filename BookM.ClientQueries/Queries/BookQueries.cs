using BookM.Application.Contracts.BooksApplication;
using BookM.ClientQueries.Model.Book.Books;
using BookM.Domain.Book.AD;

namespace BookM.ClientQueries.Queries
{
    public class BookQueries : IBookQueries
    {
        private readonly IBookApplication _bookApplication;

        public BookQueries(IBookApplication bookApplication)
        {
            _bookApplication = bookApplication;
        }

        public List<BookQueryViewModel> GetAll()
            => _bookApplication.GetAll().Select(Map).ToList();

        public List<BookQueryViewModel> GetAllBookWithCategory(int? categoryId)
            => _bookApplication.GetAll()
                .Where(x => x.CategoryId == categoryId)
                .Select(Map)
                .ToList();

        public BookQueryViewModel GetDetailInfo(int id)
            => Map(_bookApplication.GetdetailInfo(id));

        public List<BookQueryViewModel> Search(string? title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return new List<BookQueryViewModel>();

            return _bookApplication.Search(title).Select(b => new BookQueryViewModel
            {
                Id = b.Id,
                PictureFile = b.Picture,
                BookTitle = b.BookTitle,
                Writer = b.Writer,
                publisher = b.Publisher,
                CategoryId = b.CategoryId,
                CreateDateTime = b.CreatetionDate,
                IsAvailable = b.IsAvailable,
                ShortDescription = b.ShortDescription,
                CategoryName = b.Category?.Name ?? "",
                Price = b.Price,
            }).Where(x => x.BookTitle.Contains(title)).ToList();
        }

        private static BookQueryViewModel Map(BookViewModel book) => new()
        {
            Id = book.Id,
            PictureFile = book.PictureFile,
            BookTitle = book.BookTitle,
            Writer = book.Writer,
            publisher = book.publisher,
            CategoryId = book.CategoryId,
            CreateDateTime = book.CreateDateTime,
            IsAvailable = book.IsAvailable,
            ShortDescription = book.ShortDescription,
            CategoryName = book.CategoryName ?? "",
            Price = book.Price,
        };
    }
}
