using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountM.Application.Contracts.RoleApplication;
using AccountManagement.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;
using Services.Application;

namespace AccountM.Infrastructure.EFCore.Repository
{
    public class RoleRepository :RepositoryBase<Role>, IRoleRepository
    {
        private readonly AccountDbContext _accountDbContext;

        public RoleRepository(AccountDbContext accountDbContext):base(accountDbContext) 
        {
            _accountDbContext = accountDbContext;
        }

        public void create(Role Add)
        {
            _accountDbContext.Role.Add(Add);
            _accountDbContext.SaveChanges();
        }

       

        public Role GetDetails(int id)
        {
            return _accountDbContext.Role.Include(x=>x.Permissions).FirstOrDefault(x => x.Id == id);
        }

       

        public List<Role> list()
        {
            return _accountDbContext.Role.ToList();
        }

        public async Task updateby(Role update)
        {
           var ER=_accountDbContext.Role.FirstOrDefault(x=>x.Id == update.Id);
            if (ER!=null)
            {
                ER.Edit(update.RoleName, update.Permissions, update.Details,update.IsActive);
                _accountDbContext.SaveChanges();
            }
        }
    }
}
