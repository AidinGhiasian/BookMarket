using BlogM.Application;
using BlogM.Application.Contracts.EventApplication;
using BookM.ClientQueries.Model.Blog.Event;
using Services.Application;

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
            return _eventApplication.GetAll()
                .Select(x => new EventQueryViewModel
                {
                    Id = x.Id,
                    Picture = x.Picture,
                    EventTitle = x.EventTitle,
                    Description = x.Description,
                    EventStartTime = x.EventStartTime,
                    EventFinishTime = x.EventFinishTime,
                    Link = x.Link
                }).ToList();
        }
    }
}
