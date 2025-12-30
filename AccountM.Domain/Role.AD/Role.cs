
using System.Collections.Generic;
using AM.Domain.Account.AD;

namespace AccountManagement.Domain.RoleAgg
{
    public class Role 
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public List<Permission> Permissions { get; private set; }
        public List<Account> Accounts { get; private set; }

        protected Role()
        {
        }

        public Role(string name, List<Permission> permissions)
        {
            Name = name;
            Permissions = permissions;
            Accounts = new List<Account>();
        }

        public void Edit(string name, List<Permission> permissions)
        {
            Name = name;
            Permissions = permissions;
        }
    }
}