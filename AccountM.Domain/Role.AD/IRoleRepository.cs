
using System.Security.Cryptography;
using Services;


namespace AccountManagement.Domain.RoleAgg
{
    public interface IRoleRepository
    {
        public void create(Role Add);
        public Role GetRole(int id);
        Task updateby(Role update);
        public List<Role> list(string RoleName);
        public List<Role> GetAll();
        Role GetDetails(long id);
        public void Remove(long id);
    }
}
