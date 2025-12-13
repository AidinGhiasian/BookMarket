using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.BlogAD;
using Book.Infrastructure.EFCore;
using Services;

namespace BlogM.Infrastructure.EFCore.Repository
{
    public class EventRepository : RepositoryBase<Events>, IEventRepository
    {
        private readonly BlogDbContext _blogdbcontext;
        private readonly IFileUploader _fileuploader;
        public EventRepository(BlogDbContext blogdbcontext,IFileUploader fileUploader):base(blogdbcontext)
        {
            _blogdbcontext = blogdbcontext;
            _fileuploader = fileUploader;
        }
        public void Create(Events events)
        {
            _blogdbcontext.Events.Add(events);
            _blogdbcontext.SaveChanges();
        }

        public void Delete(long Id)
        {
            var DE = _blogdbcontext.Events.FirstOrDefault(e => e.Id == Id);
            if (DE != null)
            {
                _blogdbcontext.Remove(DE);
            }
        }

        public List<Events> GetAll(string eventtitle)
        {
            return _blogdbcontext.Events.Where(e=>e.EventTitle == eventtitle).ToList();
        }

        public Events GetBy(string eventtitle)
        {
         return _blogdbcontext.Events.FirstOrDefault(e => e.EventTitle == eventtitle);
        }

        public void Update(Events events)
        {
            _blogdbcontext.Update(events);
            _blogdbcontext.SaveChanges();
        }


    }
}
