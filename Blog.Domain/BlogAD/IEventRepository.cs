using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Limilabs.Mail.Appointments;
using Services;

namespace Blog.Domain.BlogAD
{
    public  interface IEventRepository:IRepositoryBase<Events>
    {
        public void Create(Events events);
        public Events? GetById(long id);
        public void  Update(Events events);
        public void Delete(long Id);
        public Events GetBy(string eventtitle);
        public List<Events> GetAll();
        public Events GetDetailes(int id);
    }
}
