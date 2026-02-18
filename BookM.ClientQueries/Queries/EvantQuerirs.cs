using BlogM.Application;
using BookM.ClientQueries.Model.Blog.Evant;

namespace BookM.ClientQueries.Queries
{
    public class EvantQuerirs : IEvantQuerirs
    {
        private readonly EventApplication _eventApplication;
        public EvantQuerirs(EventApplication eventApplication)
        {
            _eventApplication = eventApplication;
        }
        public List<EventQueryViewModel> Evants()
        {
            return _eventApplication.GetAll().Select(events => new EventQueryViewModel
            {
                Id = events.Id,
                Picture = events.Picture,
                EventTitle = events.EventTitle,
                Description = events.Description,
                EventStartTime = events.EventStartTime,
                EventFinishTime = events.EventFinishTime,
            }).ToList();

        }
    }
}
