namespace AccountManagement.Domain.RoleAgg
{
    public class Permission
    {
        public int Id { get;  set; }//کد اصلی ;برای دیتابیس به permishioncodeربطی ندارد مثل رابطه بین نام و کد ملی.....
        public int PermissionCode { get;  set; }//آیدی هر دسترسی ==>میتواند چند دسترسی داشته باشد مدیر معلوم میکند
        public string NamePermission { get;  set; }
        public int? RoleId { get;  set; }//آیدی هر نقش==>متواند فط یک نقش در سایت داشته باشد : مدیر >ادمین>کتابخان>کاربر
        public Role Role { get;  set; }
        public Permission()
        {
            
        }
        public Permission(int code) => PermissionCode = code;
        public Permission(int code, string name)
        {
            PermissionCode = code;
             NamePermission = name;
        }
    }
}
