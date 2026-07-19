using Blog.Domain.BlogAD;
using BlogM.Application.Contracts.EventApplication;
using BookM.Domain.Book.AD;
using FLEXYGO.GoogleResourceTypes;
using Services.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogM.Application
{
    public class EventApplication : IEventApplication
    {
        private readonly IEventRepository _eventrepository;
        private readonly IFileUploader _fileuploader;
        public EventApplication(IEventRepository eventRepository,IFileUploader fileUploader)
        {
            _eventrepository = eventRepository;
            _fileuploader = fileUploader;
        }
        public void Create(CreateViewModel create)
        {
            var path = "Event";
            var picturename = _fileuploader.UploadNewSize(create.FileName, path,720);
            DateTime StartdateTime = create.EventStartTime.ToGeorgianDateTime();
            DateTime EnddateTime = create.EventFinishTime.ToGeorgianDateTime();

            var CE = new Events(picturename, create.EventTitle,create.Description, StartdateTime, EnddateTime,create.Link);
            _eventrepository.Add(CE);
            _eventrepository.SaveChanges();
        }

        public void Delete(long id)
        {
            _eventrepository.Delete(id);
        }

        public List<EventViewModel> GetAll()
        {
          var AE = _eventrepository.GetAll().OrderByDescending(x=>x.Id);
            var LE = new List<EventViewModel>();
            foreach (var e in AE)
            { 
                LE.Add(map(e));
            }
            return LE;
        }

        public EventViewModel? GetById(long id)
        {
            var GE = _eventrepository.GetByLongId(id);
            return map(GE);
        }
        public EditViewModel GetDetail(long id)
        {
            var book = _eventrepository.GetByLongId(id);
            return new EditViewModel
            {
                Id = book.Id,
                Picture = book.Picture,
                EventTitle = book.EventTitle,
                EventStartTime = book.EventStartTime.ToFarsiFull(),
                EventFinishTime = book.EventFinishTime.ToFarsiFull(),
                Description = book.Description,
                Link = book.Link,
                
            };
        }
        public void Update(EditViewModel edit)
        {
            var EE = _eventrepository.GetByLongId(edit.Id);

            var picturepath=edit.Picture;
            DateTime StartdateTime = edit.EventStartTime.ToGeorgianDateTime();
            DateTime EnddateTime = edit.EventFinishTime.ToGeorgianDateTime();

            if (edit.FileName != null)
            {
                _fileuploader.Delete(edit.Picture);
                var path = "Event";
                picturepath = _fileuploader.UploadNewSize(edit.FileName, path,720);
            }
            EE.Edit(picturepath, edit.EventTitle, edit.Description, StartdateTime, EnddateTime,edit.Link);
           
            _eventrepository.SaveChanges();
        }



        private EventViewModel map(Events events)
        {
            return new EventViewModel
            {
                Id = events.Id,
                Picture = events.Picture,
                EventTitle = events.EventTitle,
                Description = events.Description,
                EventStartTime = events.EventStartTime,
                EventFinishTime = events.EventFinishTime,
                Link = events.Link,
            };
        }
    }
}
