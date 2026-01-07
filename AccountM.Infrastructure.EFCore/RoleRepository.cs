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
        }

        public List<Role> GetAll()
        {
            return _accountDbContext.Role.ToList();
        }

        public Role GetDetails(long id)
        {
            throw new NotImplementedException();
        }

        public Role GetRole(int id)
        {
            return _accountDbContext.Role.FirstOrDefault(x => x.Id == id);
        }
        public List<Role> list(string RoleName)
        {
            throw new NotImplementedException();
        }

        public void RemoveRole(int id)
        {
            throw new NotImplementedException();
        }

        public Task updateby(Role Update)
        {
            throw new NotImplementedException();
        }
    }
}
