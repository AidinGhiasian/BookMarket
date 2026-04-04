using Services.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountM.Application.Contracts.RoleApplication
{
    public interface IRoleApplication
    {
        public OperationResult Create(CreateViewModel model);
        public OperationResult Edit(EditViewModel command);
        public EditViewModel GetDetails(int id);

        public List<RoleViewModel> List();
       
    }
}
