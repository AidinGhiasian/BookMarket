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

        public void Add(Role entity)
        {
            _accountDbContext.Role.Add(entity); 
        }

        public List<Role> GetAll()
        {
            return _accountDbContext.Role.ToList();
        }

        public Role GetById(long id)
        {
            return _accountDbContext.Role.FirstOrDefault(x=>x.Id==id);
        }

        public Role GetDetails(long id)
        {
            return _accountDbContext.Role.FirstOrDefault(x=>x.Id==id);
        }

        public List<Role> list()
        {
            return _accountDbContext.Role.ToList();
        }

        public void SaveChanges()
        {
            _accountDbContext.SaveChanges();
        }
    }
}
