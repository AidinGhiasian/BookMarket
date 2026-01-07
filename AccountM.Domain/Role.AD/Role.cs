
using System.Collections.Generic;
using AM.Domain.Account.AD;

namespace AccountManagement.Domain.RoleAgg
{
    public class Role 
    {
        public long Id { get; private set; }
        public string RoleName { get; private set; }
        public List<Permission> Permissions { get; private set; }//هر نقش میتواند چند دسترسی داشته باشد ...
        public List<Account> Accounts { get; private set; }//هر نقش میتواند چند حساب داشته باشد...
        public string detales { get; set; }

        protected Role()
        {
        }

        public Role(string name, List<Permission> permissions)
        {
            RoleName = name;
            Permissions = permissions;
            Accounts = new List<Account>();
        }

        public void Edit(string name, List<Permission> permissions)
        {
            RoleName = name;
            Permissions = permissions;
        }
    }
}