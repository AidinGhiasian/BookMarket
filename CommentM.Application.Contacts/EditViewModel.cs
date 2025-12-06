using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentM.Application.Contacts
{
    public class EditViewModel
    {
        public string FullName { get; set; }
        public string Message { get; set; }
        public DateTime CommentDateTime { get; set; }= DateTime.Now;
    }
}
