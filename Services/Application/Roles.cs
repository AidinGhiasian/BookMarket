namespace Services.Application.Categoreis
{
    public static class Roles
    {
        public const string Guest = "3";
        public const string User = "2";
        public const string Admin = "1";




        public static string GetRoleBy(long id)
        {
            switch (id)
            {
                case 1:
                    return "مدیرسیستم";

                case 2:
                    return "کاربر معمولی";

                case 3:
                    return "کاربر مهمان";

                default:
                    return "";
            }
        }
    }
}
