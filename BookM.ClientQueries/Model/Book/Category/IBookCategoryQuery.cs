using System.Collections.Generic;

namespace BookM.ClientQueries.Model.Book.Category
{
    public interface IBookCategoryQuery
    {
        List<BookCategoryQueryViewModel> GetAll();
    }
}
