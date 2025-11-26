using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BlogM.Application.Contacts.PostApplication
{
    public class CreateViewModel
    {
        public string Picture { get; set; }
        public IFormFile? FileName { get; set; }
        public string BookTitle { get;  set; }
        public string Writer { get;  set; }
        public string Publisher { get;  set; }
        public string Description { get;  set; }
        public int CategoryId { get; set; }

    }
}
