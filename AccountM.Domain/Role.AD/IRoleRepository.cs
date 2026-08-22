
using System.Security.Cryptography;
using Services.Application;


namespace AccountManagement.Domain.RoleAgg
{
    public interface IRoleRepository:IRepositoryBase<Role>
    {
        public void create(Role Add);
     
        Task updateby(Role update);
        public List<Role> list();
      
        Role GetDetails(int id);
        public OperationResult DeletePermissions(int id);
    }
}
