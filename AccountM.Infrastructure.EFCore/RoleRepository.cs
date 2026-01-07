using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManagement.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;

namespace AccountM.Infrastructure.EFCore.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AccountDbContext _accountDbContext;

        public RoleRepository(AccountDbContext accountDbContext)
        {
            _accountDbContext = accountDbContext;
        }

        public void create(Role Add)
        {
            _accountDbContext.Role.Add(Add);
            _accountDbContext.SaveChanges();
        }

        public List<Role> GetAll()
        {
            return _accountDbContext.Role.ToList();
        }

        public Role GetDetails(long id)
        {
            return _accountDbContext.Role.FirstOrDefault(x => x.Id == id);
        }

        public Role GetRole(int id)
        {
            return _accountDbContext.Role.FirstOrDefault(x => x.Id == id);
        }
        public List<Role> list(string rolename)
        {
            return _accountDbContext.Role.Where(x=>x.RoleName.Contains(rolename)).ToList();//اگر بزنم xنقش هایی که داخل ان ها xدارد را می اورد....
        }

        public void Remove(long id)
        {
            var role = _accountDbContext.Role.FindAsync(id);
            if (role!=null)
            {
                _accountDbContext.Remove(role);
                _accountDbContext.SaveChanges();
            }
        }

        public async Task updateby(Role update)
        {
           var ER=_accountDbContext.Role.FirstOrDefault(x=>x.Id == update.Id);
            if (ER!=null)
            {
                ER.Edit(update.RoleName, update.Permissions, update.Details);
                _accountDbContext.SaveChanges();
            }
        }
    }
}
