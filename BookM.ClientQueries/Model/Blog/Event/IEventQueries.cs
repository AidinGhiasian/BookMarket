using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookM.ClientQueries.Model.Blog.Event
{
    public interface IEventQueries
    {
        public List<EventQueryViewModel> Events();
    }
}
