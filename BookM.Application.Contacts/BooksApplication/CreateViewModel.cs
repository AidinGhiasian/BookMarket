using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BookM.Application.Contacts.BooksApplication
{
    public class CreateViewModel
    {
        [Display(Name = "")]
        public string Picture { get; set; }
        public IFormFile? FileName { get; set; }
        public string BookTitle { get; set; }
        public string Writer { get; set; }
        public string Publisher { get; set; }
        public int CategoryId { get; set; }
    }
}
