using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.BlogAD;
using BlogM.Application.Contacts.EventApplication;
using Services;

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
            var path = create.Picture;
            var picturename = _fileuploader.UploadNewSize(create.FileName, path,720);
            var CE = new Events(picturename, create.EventTitle,
                create.Description, create.EventStartTime, create.EventFinishTime);
            _eventrepository.Add(CE);
        }

        public void Delete(long id)
        {
            _eventrepository.Delete(id);
        }

        public List<EventViewModel> GetAll(string EventTitle)
        {
          var AE = _eventrepository.GetAll();
            var LE = new List<EventViewModel>();
            foreach (var e in AE)
            { 
                LE.Append(map(e));
            }
            return LE;
        }

        public EventViewModel? GetById(long id)
        {
           var GE = _eventrepository.GetById(id);
            return map(GE);
        }

        public void Update(EditViewModel edit)
        {
            var EE = _eventrepository.GetById(edit.Id);

            var picturepath=edit.Picture;

            if (edit.FileName != null)
            {
                _fileuploader.Delete(edit.Picture);
                var newpath = "picture";
                picturepath = _fileuploader.UploadNewSize(edit.FileName, newpath,720);
            }
            EE.Edit(edit.Picture, edit.EventTitle, edit.Description,edit.EventStartTime,edit.EventFinishTime);
            _eventrepository.Update(EE);
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
            };
        }
    }
}
