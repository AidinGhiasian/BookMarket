
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace BookM.Domain.Book.AD
{
    public class Books
    {
        public int Id { get; private set; }
        public string? Picture { get; private set; }
        [NotMapped]
        public IFormFile? PictureFile { get; private set; }
        public string BookTitle { get; private set; }
        public string Writer { get; private set; }
        public string Publisher { get; private set; }
        public int CategoryId { get; private set; }
        public DateTime CreatetionDate { get; private set; }
        public DateTime UpdatedTime { get; private set; }
        public bool IsAvailable { get; private set; }
        public string Price { get;private set; }


        public Books() { }


        //رابطه با BookCategory با رابطه چند به چند
        public List<BookCategories> BookCategories { get; private set; } = new();

        public Books(string picture, string booktitle, string writer, string publisher, int categoryId, string price, IFormFile formFile = null)
        {
            PictureFile = PictureFile;
            BookTitle = booktitle;
            Writer = writer;
            Publisher = publisher;
            CategoryId = categoryId;
            PictureFile = formFile;
            CreatetionDate = DateTime.Now;
            UpdatedTime = DateTime.Now;
            IsAvailable = true;
            Price = price;
        }

        public void Edit(string picture,string bookTitle, string writer, string publisher, int categoryId, bool statusAvailable,string price)
        {
            if(picture!=null)
                Picture = picture;
            BookTitle = bookTitle;
            Writer = writer;
            Publisher = publisher;
            CategoryId = categoryId;
            UpdatedTime = DateTime.Now;
            IsAvailable = statusAvailable;
            Price = price;
        }
    }
}

