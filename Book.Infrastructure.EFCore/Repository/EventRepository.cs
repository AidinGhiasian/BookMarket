using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.BlogAD;
using Book.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore.Internal;
using Services.Application;

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
            _blogdbcontext.SaveChanges();
        }

        public List<Events> GetAll()
        {
            return _blogdbcontext.Events.ToList();
        }

        public Events GetBy(string eventtitle)
        {
         return _blogdbcontext.Events.FirstOrDefault(e => e.EventTitle == eventtitle);
        }

        public Events GetDetailes(int id)
        {
          return _blogdbcontext.Events.FirstOrDefault(x => x.Id == id);
        }

        


    }
}
