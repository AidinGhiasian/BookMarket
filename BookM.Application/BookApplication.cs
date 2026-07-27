using BookM.Application.Contracts.BooksApplication;
using BookM.Application.Contracts.BooksCategoryApplication;
using BookM.Domain.Book.AD;
using BookM.Infrastructure.EFCore.Repository;
using Services.Application;

namespace BookM.Application
{
    public class BookApplication : IBookApplication
    {
        private readonly IBookRepository _bookRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IBookCategoryRepository _bookCategoryRepository;

        public BookApplication(IBookRepository bookRepository,
            IFileUploader fileUploader,
            IBookCategoryRepository bookCategoryRepository)
        {
            _bookRepository = bookRepository;
            _fileUploader = fileUploader;
            _bookCategoryRepository = bookCategoryRepository;
        }

        public void Create(CreateViewModel create)
        {
            var pictureName = "";
            if (create.FileName != null)
                pictureName = _fileUploader.UploadNewSize(create.FileName, "Book", 720);

            if (!long.TryParse(create.Price, out var price))
                throw new InvalidOperationException("قیمت باید یک عدد صحیح باشد.");

            var book = new Books(pictureName, create.BookTitle, create.Writer, create.Publisher,
                create.CategoryId, price, create.shortdescription);
            _bookRepository.Create(book);
        }

        public void Delete(int id) => _bookRepository.Delete(id);

        public Books? GetById(int id) => _bookRepository.GetById(id);

        public List<BookViewModel> GetAll() => _bookRepository.GetBy().Select(Map).ToList();

        public void Edit(EditViewModel update)
        {
            var book = _bookRepository.GetById(update.Id);
            if (book == null) throw new InvalidOperationException(ApplicationMessage.NotFound);

            var pictureName = book.Picture ?? "";
            if (update.FileName != null)
            {
                if (!string.IsNullOrWhiteSpace(book.Picture))
                    _fileUploader.Delete(book.Picture);
                pictureName = _fileUploader.UploadNewSize(update.FileName, "Book", 720);
            }

            if (!long.TryParse(update.Price, out var price))
                throw new InvalidOperationException("قیمت باید یک عدد صحیح باشد.");

            book.Edit(pictureName, update.BookTitle, update.Writer, update.Publisher,
                update.CategoryId, update.status, price, update.shortdescription);

            _bookRepository.SaveChanges();
        }

        private BookViewModel Map(Books book)
        {
            return new BookViewModel
            {
                Id = book.Id,
                PictureFile = book.Picture,
                BookTitle = book.BookTitle,
                Writer = book.Writer,
                publisher = book.Publisher,
                CategoryId = book.CategoryId,
                CreateDateTime = book.CreatetionDate,
                IsAvailable = book.IsAvailable,
                ShortDescription = book.ShortDescription,
                Price = book.Price,
                CategoryName = book.Category?.Name,
            };
        }

        public EditViewModel Getdetail(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book == null) throw new InvalidOperationException(ApplicationMessage.NotFound);
            return new EditViewModel
            {
                Id = book.Id,
                Picture = book.Picture,
                BookTitle = book.BookTitle,
                Writer = book.Writer,
                Publisher = book.Publisher,
                CategoryId = book.CategoryId,
                shortdescription = book.ShortDescription,
                Categorey = book.Category?.Name ?? "",
                Price = book.Price.ToString(),
                status = book.IsAvailable,
            };
        }

        public BookViewModel GetdetailInfo(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book == null) throw new InvalidOperationException(ApplicationMessage.NotFound);
            return Map(book);
        }

        public List<Books> Search(string title) => _bookRepository.GetBy(title);
    }
}
