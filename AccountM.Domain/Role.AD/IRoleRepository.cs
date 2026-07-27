using Services.Application;

namespace AccountManagement.Domain.RoleAgg
{
    public interface IRoleRepository : IRepositoryBase<Role>
    {
        void Create(Role add);
        Task UpdateAsync(Role update);
        List<Role> List();
        Role? GetDetails(int id);
    }
}
