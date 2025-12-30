
using Services;


namespace AccountManagement.Domain.RoleAgg
{
    public interface IRoleRepository : IRepositoryBase<Role>
    {
        List<Role> list();
        Role GetDetails(long id);
    }
}
