using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookToBookM.Domain.BookToBook.AD
{
    public class ExchangeBook //نماینده‌ی خود معامله/مبادله بین دو طرف است.
    {
        public long Id { get; set; }

        public long? BookManagementId { get; set; }

        public long UserId { get; set; }

        public string Title { get; set; } = null!;

        public string Writer { get; set; } = null!;

        public string? ISBN { get; set; }

        public string? PictureFile { get; set; }

        public decimal Price { get; set; }
    }
}
