using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountM.Application.Contracts.AccountApplication;
using AccountM.Application.Contracts.RoleApplication;
using AccountManagement.Domain.RoleAgg;
using AM.Domain.Account.AD;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services;

namespace AccountM.Application
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IRoleRepository _roleRepository;
        public RoleApplication(IRoleRepository rolerepository)
        {
            _roleRepository = rolerepository;
        }


        public void delete(long id)
        {
            var role=_roleRepository.GetbyId(id);
            role.ChengeStatus(false);
            _roleRepository.SaveChanges();
         
          
        }



        public RoleViewModel GetById(long id)
        {
           var gr = _roleRepository.GetbyId(id);
            return Map(gr);
        }

        public List<RoleViewModel> getRole()
        {
            var roles=_roleRepository.GetAll();
            var list = new List<RoleViewModel>();
            foreach(var role in roles )
            {
                list.Append(Map(role));
            }
            return list;
        }
        
        void IRoleApplication.Create(Contracts.RoleApplication.CreateViewModel model)//کامپایلر نمیتوانست تشیص دهد منظور من کدام CreateViewModelاست...
        {
            var cr = new Role(model.RoleName, model.Permissions, model.details);
             _roleRepository.create(cr);
        }

        Task IRoleApplication.Edit(Contracts.RoleApplication.EditViewModel model)//کامپایلر نمیتوانست تشیص دهد منظور من کدام Edit ViewModelاست...
        {
            var er = _roleRepository.GetbyId(model.Id);
            er.Edit(model.RoleName,model.Permissions,model.details,model.isActive);
            return _roleRepository.updateby(er);
        }


        //maps
        private RoleViewModel Map(Role model)
        {
            return new RoleViewModel
            {
                Id = model.Id,
                RoleName= model.RoleName,
                Details= model.Details,
            };
        }
    }
}

