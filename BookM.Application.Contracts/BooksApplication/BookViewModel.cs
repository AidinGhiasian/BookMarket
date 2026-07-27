using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using BookM.Application.Contracts.BooksCategoryApplication;

namespace BookM.Application.Contracts.BooksApplication
{
    public class BookViewModel
    {
        [Display(Name = "شناسه یکتا")]
        public int Id { get; set; }


        [Display(Name = "فایل تصویری")]
        public string PictureFile { get; set; }
        public IFormFile? FileName { get; set; }


        [Required(ErrorMessage = "لطفا عنوان کتاب را وارد کنید...")]
        [Display(Name = "عنوان کتاب")]
        public string BookTitle { get; set; }

        [Required(ErrorMessage = "لطفا نویسنده کتاب را وارد کنید...")]
        [Display(Name = "نویسنده")]
        public string Writer { get; set; }

        [Required(ErrorMessage = "لطفا ناشر کتاب را وارد کنید...")]
        [Display(Name = "ناشر")]
        public string publisher { get; set; }

        [Required(ErrorMessage = "لطفا شماره دسته بندی کتاب را وارد کنید...")]
        [Display(Name = "شماره دسته بندی")]
        [StringLength(20, ErrorMessage = "شما نمیتونید بیشتر از مقدار 20 کارکتر وارد نمایید...")]
        public int CategoryId { get; set; }

        [Display(Name = "تاریخ تولید کتاب")]
        public DateTime CreateDateTime { get; set; }

        [Required(ErrorMessage = "لطفا مقدار فعال/غیرفعال کتاب را وارد کنید...")]
        [Display(Name = "فعال/غیرفعال")]
        public bool IsAvailable { get; set; }

        [Required(ErrorMessage = "لطفا قیمت کتاب را وارد کنید...")]
        [Display(Name = "قیمت کتاب")]
        public long Price { get; set; }
        [Required(ErrorMessage = "لطفا توضیحات کوتاه را وارد کنید...")]
        [Display(Name = "توضیحات کوتاه")]
        public string ShortDescription { get; set; }
        public BookCategoryViewModel BookCategories { get; set; }
        public string CategoryName { get; set; }

    }
}
