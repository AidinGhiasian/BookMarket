using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BlogM.Application.Contracts.EventApplication
{
    public class CreateViewModel
    {
        public long Id { get; set; }
        public string Picture { get; set; }
        public string EventTitle { get; set; }
        public string Description { get; set; }
        public string EventStartTime { get; set; }
        public string EventFinishTime { get; set; }
        public IFormFile FileName { get; set; }
        public string Link { get; set; }
    }
}
