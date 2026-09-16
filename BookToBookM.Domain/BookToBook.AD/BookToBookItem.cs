using BookToBookM.Domain.BookToBook.AD.Enum;

namespace BookToBook.AD
{
    public class BookToBookItem
    {
        public long Id { get; set; }

        public long BookId { get; set; }

        public long UserId { get; set; }

        public decimal FairPrice { get; set; }

        public BookToBookStatus Status { get; set; }
    }
}