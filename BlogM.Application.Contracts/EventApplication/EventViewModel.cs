using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogM.Application.Contracts.EventApplication
{
    public class EventViewModel
    {
        [Display(Name = "شناسه یکتا")]
        public long Id { get; set; }


        [Display(Name = "لینک تصویر ")]
        public string Picture { get; set; }


        [Display(Name = "موضوع رویداد")]
        public string EventTitle {  get; set; }


        [Display(Name = "توضیحات")]
        public string  Description { get; set; }


        [Display(Name = "تاریخ شروع رویداد")]
        public DateTime EventStartTime { get; set; }


        [Display(Name = "تاریخ پایان رویداد")]
        public DateTime EventFinishTime { get; set; }

        [Display(Name = "لینک مقاله یا کتاب")]
        public string Link { get; set; }
    }
}
