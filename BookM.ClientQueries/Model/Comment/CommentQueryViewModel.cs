using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookM.ClientQueries.Model.Comment
{
    public class CommentQueryViewModel
    {
        [Display(Name = "شناسه یکتا")]
        public long Id { get; set; }



        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا نام و نام خانوادگی خود را وارد کنید...")]
        public string FullName { get; set; }



        [Display(Name = "نظر شما")]
        [Required(ErrorMessage = "لطفا فورم نظر خود را بنویسید...")]
        public string Message { get; set; }



        [Display(Name = "کد کتاب ")]
        [Required(ErrorMessage = "مقدار کد کتاب اشتباه میباشد...")]
        public long OwnerId { get; set; }



        [Display(Name = "کتاب یا بلاگ")]
        [Required(ErrorMessage = "مقدار تایپی که برای تایین کردن کتاب یا بلاگ وارد کرده اید اشتباه است... ")]
        public int Type { get; set; }



        [Display(Name = "زمان کامنت")]
        public DateTime CommentDateTime { get; set; }


        [Display(Name = "تایید نشدن کد")]
        public int IsStatus { get; set; }
    }
}
