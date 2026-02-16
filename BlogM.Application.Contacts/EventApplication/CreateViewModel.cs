using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BlogM.Application.Contacts.EventApplication
{
    public class CreateViewModel
    {
        public long Id { get; set; }
        public string Picture { get; set; }
        public string EventTitle { get; set; }
        public string Description { get; set; }
        public DateTime EventStartTime { get; set; }
        public DateTime EventFinishTime { get; set; }
        public IFormFile FileName { get; set; }
    }
}
