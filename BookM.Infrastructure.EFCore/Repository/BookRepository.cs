using BookM.Application.Contracts.BooksApplication;
using BookM.Domain.Book.AD;
using Microsoft.EntityFrameworkCore;
using Services.Application;

namespace BookM.Infrastructure.EFCore.Repository
{
    public class BookRepository : RepositoryBase<Books>, IBookRepository
    {
        private readonly BookDbContext _bookdbcontext;
        private readonly IFileUploader _fileUploader;

        public BookRepository(BookDbContext bookDbContext, IFileUploader fileUploader) : base(bookDbContext)
        {
            _fileUploader = fileUploader;
            _bookdbcontext = bookDbContext;
        }

        public List<Books> GetAllWithCategory()
            => _bookdbcontext.Books.Include(c => c.Category).Where(x => x.IsAvailable).ToList();

        public void Create(Books books)
        {
            _bookdbcontext.Books.Add(books);
            _bookdbcontext.SaveChanges();
        }

        public void Delete(int id)
        {
            var DB = _bookdbcontext.Books.Find(id);
            if (DB == null) return;
            _bookdbcontext.Books.Remove(DB);
            _bookdbcontext.SaveChanges();
        }

        public Books? Getby(string Title)
            => _bookdbcontext.Books.FirstOrDefault(x => x.BookTitle == Title);

        public List<Books> GetBy()
            => _bookdbcontext.Books.Include(x => x.Category).Where(x => x.IsAvailable).ToList();

        public Books? GetById(int id)
            => _bookdbcontext.Books.Include(x => x.Category).FirstOrDefault(x => x.Id == id);

        public async Task Updateby(Books book)
        {
            var EB = _bookdbcontext.Books.FirstOrDefault(x => x.Id == book.Id);
            if (EB == null) return;

            EB.Edit(book.Picture, book.BookTitle, book.Writer, book.Publisher,
                book.CategoryId, book.IsAvailable, book.Price, book.ShortDescription);
            await _bookdbcontext.SaveChangesAsync();
        }

        public List<Books> GetBy(string? title)
        {
            IQueryable<Books> q = _bookdbcontext.Books.Include(x => x.Category).Where(x => x.IsAvailable);
            if (!string.IsNullOrWhiteSpace(title))
                q = q.Where(x => x.BookTitle.Contains(title));
            return q.ToList();
        }
    }
}
