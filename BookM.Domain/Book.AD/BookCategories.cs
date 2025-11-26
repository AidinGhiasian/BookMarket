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

        public DateTime CreatedAt { get; private set; }      // تاریخ ایجاد

        // ارتباط با کتاب‌ها 
        public List<Books> Books { get; private set; } = new();

        // سازنده
        public BookCategories(string name, string? description = null)
        {
            Name = name;
            Description = description;
            CreatedAt = DateTime.Now;
        }

        // متدهای مدیریتی
        public void UpdateCategory(string name, string? description = null)
        {
            Name = name;
            Description = description;
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
