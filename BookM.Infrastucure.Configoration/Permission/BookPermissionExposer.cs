using Services.Infrastructure;

namespace BookMInfrastucureConfiguration.Permission
{
    public class BookPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDTO>> Expose()
        {
            return new Dictionary<string, List<PermissionDTO>>
            {
                {
                    "Book",new List<PermissionDTO>
                    {
                        new PermissionDTO(BookPermission.ListBook,"لیست کتاب ها "),
                        new PermissionDTO(BookPermission.CreateBook,"ساخت کتاب"),
                        new PermissionDTO(BookPermission.EditBook,"ویرایش کتاب"),
                        new PermissionDTO(BookPermission.SearchBook,"جستجوی کتاب "),
                        new PermissionDTO(BookPermission.DeleteBook,"حذف کتاب "),
                    }
                },
                {
                    "دسته بندی کتاب",new List<PermissionDTO>
                    {
                        new PermissionDTO(BookPermission.ListBookCategory,"لیست دسته بندی کتاب ها "),
                        new PermissionDTO(BookPermission.CreateBookCategory,"ساخت دسته بندی کتاب"),
                        new PermissionDTO(BookPermission.SearchBookCategory,"جستجوی دسته بندی کتاب"),
                        new PermissionDTO(BookPermission.EditBookCategory,"ویرایش دسته بندی کتاب"),
                        new PermissionDTO(BookPermission.DeleteBookCategory,"حذف دسته بندی کتاب"),
                    }
                }
            };
        }
    }
}
