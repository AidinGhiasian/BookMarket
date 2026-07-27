using System.ComponentModel.DataAnnotations;

namespace CommentM.Application.Contracts
{
    public class CreateViewModel
    {
        [Required(ErrorMessage = "نام الزامی است")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "متن نظر الزامی است")]
        public string Message { get; set; }

        public DateTime CommentDatetime { get; set; }

        public int OwnerId { get; set; }

        /// <summary>
        /// 1 = Book, 2 = Blog, 3 = Event
        /// </summary>
        public int Type { get; set; } = 1;
    }
}
