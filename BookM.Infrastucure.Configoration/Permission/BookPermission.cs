using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMInfrastucureConfiguration.Permission
{
    public class BookPermission
    {
        //Book
        public const int ListBook = 300;
        public const int SearchBook = 301;
        public const int CreateBook = 302;
        public const int EditBook = 303;
        //BookCategory
        public const int ListBookCategory = 304;
        public const int SearchBookCategory = 305;
        public const int CreateBookCategory = 306;
        public const int EditBookCategory = 307;
    }
}