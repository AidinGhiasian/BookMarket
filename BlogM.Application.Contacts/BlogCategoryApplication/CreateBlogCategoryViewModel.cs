using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogM.Application.Contacts.BlogCategoryApplication
{
    public class CreateBlogCategoryViewModel
    {
        [Required(ErrorMessage = "نام دسته‌بندی الزامی است")]
        [MaxLength(200, ErrorMessage = "نام نمی‌تواند بیشتر از 200 کاراکتر باشد")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Slug الزامی است")]
        [MaxLength(300)]
        public string Slug { get; set; }

        [MaxLength(500, ErrorMessage = "توضیحات نمی‌تواند بیشتر از 500 کاراکتر باشد")]
        public string Description { get; set; }
        public IFormFile Picture { get; set; }
    }

}
