using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.BlogAD
{
    public class Events
    {
        public long Id { get; private set; }
        public string Picture { get; private set; }
        public string EventTitle { get; private set; }
        public string Description { get; private set; }
        public DateTime EventStartTime { get; private set; }
        public DateTime EventFinishTime { get; private set; }



        private Events() { }

        public Events(string picture, string eventTitle, string description,DateTime EventStartTime, DateTime EventFinishTime)
        {
            Picture = picture;
            EventTitle = eventTitle;
            Description = description;
            EventStartTime = EventStartTime;
            EventFinishTime = EventFinishTime;
        }
        public void Edit(string picture, string eventTitle, string description, DateTime EventStartTime, DateTime EventFinishTime)
        {
            if(picture != null)
            Picture = picture;
            EventTitle = eventTitle;
            Description = description;
            EventStartTime = EventStartTime;
            EventFinishTime= EventFinishTime;
        }
    }
}
