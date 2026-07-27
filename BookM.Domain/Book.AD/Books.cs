using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace BookM.Domain.Book.AD
{
    public class Books
    {
        public int Id { get; private set; }
        public string? Picture { get; private set; }
        public string BookTitle { get; private set; }
        public string Writer { get; private set; }
        public string Publisher { get; private set; }
        public int CategoryId { get; private set; }
        public string ShortDescription { get; set; }
        public DateTime CreatetionDate { get; private set; }
        public DateTime UpdatedTime { get; private set; }
        public bool IsAvailable { get; private set; }

        public long Price { get; private set; }

        public BookCategories? Category { get; private set; }

        private Books() { }

        public Books(string? picture, string booktitle, string writer, string publisher,
            int categoryId, long price, string shortdescription)
        {
            Picture = picture;
            BookTitle = booktitle;
            Writer = writer;
            Publisher = publisher;
            CategoryId = categoryId;
            CreatetionDate = DateTime.Now;
            UpdatedTime = DateTime.Now;
            IsAvailable = true;
            Price = price;
            ShortDescription = shortdescription;
        }

        public void Edit(string? picture, string bookTitle, string writer, string publisher,
            int categoryId, bool statusAvailable, long price, string shortdescription)
        {
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            BookTitle = bookTitle;
            Writer = writer;
            Publisher = publisher;
            CategoryId = categoryId;
            UpdatedTime = DateTime.Now;
            IsAvailable = statusAvailable;
            Price = price;
            ShortDescription = shortdescription;
        }
    }
}
