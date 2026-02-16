using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogM.Application.Contacts.EventApplication
{
    public interface IEventApplication
    {
        public void Create(CreateViewModel create);
        public EventViewModel? GetById(long id);
        public void Update(EditViewModel edit);
        public void Delete(long id);
        public List<EventViewModel> GetAll();
    }
}
