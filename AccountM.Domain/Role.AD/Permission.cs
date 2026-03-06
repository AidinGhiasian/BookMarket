namespace AccountManagement.Domain.RoleAgg
{
    public class Permission
    {
        public int Id { get; private set; }//کد اصلی ;برای دیتابیس به permishioncodeربطی ندارد مثل رابطه بین نام و کد ملی.....
        public int PermissionCode { get; private set; }//آیدی هر دسترسی ==>میتواند چند دسترسی داشته باشد مدیر معلوم میکند
        public string NamePermission { get; private set; }
        public int? RoleId { get; private set; }//آیدی هر نقش==>متواند فط یک نقش در سایت داشته باشد : مدیر >ادمین>کتابخان>کاربر
        public Role Role { get; private set; }

        public Permission()
        {
            
        }
        public Permission(int code, string name)
        {
            PermissionCode = code;
             NamePermission = name;
        }
    }
}
