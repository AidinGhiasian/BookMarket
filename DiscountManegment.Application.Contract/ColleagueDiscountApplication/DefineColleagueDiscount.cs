



using BookM.Application.Contracts.BooksApplication;

namespace DiscountManegment.Application.Contract.ColleagueDiscountApplication
{

    public class DefineColleagueDiscount
    {
        public long PoroductId { get; set; }
        public int DiscountRate { get; set; }
        public List<BookViewModel>  Products { get; set; }
    }
}
