using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookM.Domain.Book.AD
{
    public class BookCategories
    {
        public int Id { get; private set; }                  // شناسه دسته‌بندی
        public string Name { get; private set; }             // نام دسته
        public string? Description { get; private set; }     // توضیح دسته (اختیاری)
        public string Picture {  get; private set; }
        public DateTime CreatedAt { get; private set; }      // تاریخ ایجاد

        // ارتباط با کتاب‌ها 
        public List<Books> Books { get; private set; } = new();

        // سازنده
        public BookCategories(string name, string picture, string? description = null )
        {
            Name = name;
            Description = description;
            CreatedAt = DateTime.Now;
            Picture = picture;
        }

        // متدهای مدیریتی
        public void UpdateCategory(string name, string picture, string? description = null)
        {
            Name = name;
            Description = description;
            if ( picture != null )
                Picture = picture;
        }

        public void AddBook(Books book)
        {
            Books.Add(book);
        }

        public void RemoveBook(Books book)
        {
            Books.Remove(book);
        }
    }

}
