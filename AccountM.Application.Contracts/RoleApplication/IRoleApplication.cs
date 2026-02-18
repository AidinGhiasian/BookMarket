using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountM.Application.Contracts.RoleApplication
{
    public interface IRoleApplication
    {
        public void Create(CreateViewModel model);
        Task Edit(EditViewModel model);
        public RoleViewModel GetById(long id);
        List<RoleViewModel>getRole();
        public void delete(long id);
    }
}
