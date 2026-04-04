namespace Services.Application.Categoreis
{
    public static class Roles
    {
        public const string User = "2";
        public const string Admin = "1";
      



        public static string GetRoleBy(long id)
        {
            switch (id)
            {
                case 2:
                    return "مدیرسیستم";
                case 3:
                    return "کاربر معمولی  ";
               
                default:
                    return "";
            }
        }
    }
}
