
using System.Collections.Generic;
using AM.Domain.Account.AD;

namespace AccountManagement.Domain.RoleAgg
{
    public class Role
    {
        public int Id { get; private set; }
        public string RoleName { get; private set; }
        public List<Permission> Permissions { get; private set; }//هر نقش میتواند چند دسترسی داشته باشد ...
        public List<Account> Accounts { get; private set; }//هر نقش میتواند چند حساب داشته باشد...
        public string Details { get; private set; }//توضیحات درباره نقش...
        public bool IsActive { get; private set; }

        protected Role()
        {
        }

        public Role(string rolename, List<Permission> permissions, string details)
        {
            RoleName = rolename;
            Permissions = permissions;
            Details = details;
            Accounts = new List<Account>();
            IsActive = true;
        }

        public void Edit(string name, List<Permission> permissions, string details, bool isActive)
        {
            RoleName = name; 
            Permissions = permissions;
            Details = details;
            IsActive = isActive;
        }
        public void ChengeStatus(bool status)
        {
            IsActive = status;
        }

    }
}