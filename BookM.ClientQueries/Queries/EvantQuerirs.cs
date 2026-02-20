using BlogM.Application;
using BlogM.Application.Contracts.EventApplication;
using BookM.ClientQueries.Model.Blog.Evant;

namespace BookM.ClientQueries.Queries
{
    public class EvantQuerirs : IEventQueries
    {
        private readonly IEventApplication _eventApplication;
        public EvantQuerirs(IEventApplication eventApplication)
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
