using AccountManagement.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;
using Services.Application;

namespace AccountM.Infrastructure.EFCore.Repository
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        private readonly AccountDbContext _accountDbContext;

        public RoleRepository(AccountDbContext accountDbContext) : base(accountDbContext)
        {
            _accountDbContext = accountDbContext;
        }

        public void Create(Role add)
        {
            _accountDbContext.Role.Add(add);
            _accountDbContext.SaveChanges();
        }

        public Role? GetDetails(int id)
            => _accountDbContext.Role.Include(x => x.Permissions).FirstOrDefault(x => x.Id == id);

        public List<Role> List() => _accountDbContext.Role.Include(x => x.Permissions).ToList();

        public async Task UpdateAsync(Role update)
        {
            var er = _accountDbContext.Role.FirstOrDefault(x => x.Id == update.Id);
            if (er == null) return;
            er.Edit(update.RoleName, update.Permissions, update.Details, update.IsActive);
            await _accountDbContext.SaveChangesAsync();
        }
    }
}
