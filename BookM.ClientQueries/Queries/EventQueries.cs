using BlogM.Application;
using BlogM.Application.Contracts.EventApplication;
using BookM.ClientQueries.Model.Blog.Event;

namespace BookM.ClientQueries.Queries
{
    public class EventQueries : IEventQueries
    {
        private readonly IEventApplication _eventApplication;
        public EventQueries(IEventApplication eventApplication)
        {
            _eventApplication = eventApplication;
        }
        public List<EventQueryViewModel> Events()
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
