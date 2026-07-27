namespace Services.Application.Categoreis
{
    public static class Roles
    {
        // Use these with [Authorize(Roles = Roles.Admin)] and ClaimTypes.Role
        public const string Admin = "Admin";
        public const string User = "User";

        // Database role IDs
        public const int AdminId = 1;
        public const int UserId = 2;

        public static string GetRoleNameById(long id)
        {
            return id switch
            {
                AdminId => Admin,
                UserId => User,
                _ => string.Empty,
            };
        }

        public static string GetRoleFriendlyName(long id)
        {
            return id switch
            {
                AdminId => "مدیر سیستم",
                UserId => "کاربر معمولی",
                _ => string.Empty,
            };
        }
    }
}
