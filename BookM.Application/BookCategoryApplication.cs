using BookM.Application.Contracts.BooksApplication;
using BookM.Application.Contracts.BooksCategoryApplication;
using BookM.Domain.Book.AD;
using Services.Application;

namespace BookM.Application
{
    public class BookCategoryApplication : IBookCategoryApplication
    {
        private readonly IBookCategoryRepository _bookcategory;
        private readonly IFileUploader _fileUploader;
        public BookCategoryApplication(IBookCategoryRepository bookcategory, IFileUploader fileUploder)
        {
            _bookcategory = bookcategory;
            _fileUploader = fileUploder;
        }

        public void Create(BookCategoryCreateViewModel create)
        {
            var pictureName = "";
            if (create.FileName != null)
            {
                var path = "Category";
                pictureName = _fileUploader.UploadNewSize(create.FileName, path, 720);
            }
            var category = new BookCategories(create.CategoryName, pictureName, create.Description);
            _bookcategory.Add(category);
            _bookcategory.SaveChanges();
        }

        public bool Delete(int id)
        {
            var category = _bookcategory.GetById(id);

            _fileUploader.Delete(category.Picture);

            var result = _bookcategory.Deleted(id);
            return result;
        }



        public void Edit(BookCategoryEditViewModel update)
        {

            var category = _bookcategory.GetById(update.Id);
            if (category != null)
            {
                var pictureName = category.Picture;
                if (update.FileName != null)
                {
                    _fileUploader.Delete(category.Picture);
                    var path = "Category";
                    pictureName = _fileUploader.UploadNewSize(update.FileName, path, 720);
                }
                category.UpdateCategory(update.CategoryName, pictureName, update.Description);

                _bookcategory.SaveChanges();
            }
        }

        public List<BookCategoryViewModel> GetAll()
        {
            var list = _bookcategory.GetAll();
            return Maplist(list);
        }
        public BookCategoryEditViewModel GetById(int id)
        {
            var category = _bookcategory.GetById(id);

            return MapforEdit(category);
        }
        public BookCategoryEditViewModel MapforEdit(BookCategories cat)
        {
            var categpry = new BookCategoryEditViewModel
            {
                Id = cat.Id,
                CategoryName = cat.Name,
                Description = cat.Description,
                pictureName = cat.Picture,
            };
            return categpry;
        }
        public BookCategoryViewModel Map(BookCategories cat)
        {
            var categpry = new BookCategoryViewModel
            {
                Id = cat.Id,
                CategoryName = cat.Name,
                Description = cat.Description,
                Picture = cat.Picture,
            };
            return categpry;
        }
        public List<BookCategoryViewModel> Maplist(List<BookCategories>? cats)
        {
            var categpry = new List<BookCategoryViewModel>();
            if (cats != null)
            {
                foreach (var cat in cats)
                {
                    categpry.Add(Map(cat));
                }
            }

            return categpry;
        }
        public BookCategories? GetbyId(int id)
        {
            var bookget = _bookcategory.GetById(id);
            if (bookget != null)
            {
                return bookget;
            }
            return null;
        }
    }
}
