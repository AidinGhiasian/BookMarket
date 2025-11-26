using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogM.Application.Contacts.PostApplication
{
    public  class PostViewModel
    {
        public int Id { get;  set; }
        public string Picture { get;  set; }
        public string BookTitle { get;  set; }
        public string Writer { get;  set; }
        public string Publisher { get;  set; }
        public string Description { get; set; }
        public int CategoryId { get;  set; }
        public DateTime PostTime { get;  set; }
        public DateTime UpdatedTime { get;  set; }
        public bool IsAvailable { get; set; }

    }
}
