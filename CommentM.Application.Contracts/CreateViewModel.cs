using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentM.Application.Contracts
{
    public class CreateViewModel
    {
        public string FullName { get; set; }
        public string Message { get; set; }
        public DateTime CommentDatetime { get; set; }
        public int OwnerId { get; set; }
    }
} 
