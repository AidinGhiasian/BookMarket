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
       
        public IFormFile? FileName { get; set; }
        public string Title { get;  set; }
        public string ShortDescription { get;  set; }
        public string Description { get;  set; }

    }
}
