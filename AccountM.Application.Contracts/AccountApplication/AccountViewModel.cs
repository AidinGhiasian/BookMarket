using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountM.Application.Contracts.AccountApplication
{
    public class AccountViewModel
    {
        
        [Display(Name = "شناسه یکتا")]
        public int Id { get; set; }

        

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا نام خود را وارد کنید...")]
        public string Name { get; set; }


        [Display(Name="نام خانوادگی")]
        [Required(ErrorMessage = "لطفا نام خانوادگی خود را وارد کنید...")]
        public string Family { get; set; }



        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "لطفا شماره تلفن خود را وارد کنید...")]
        [RegularExpression("09(1[0-9]|3[1-9]|2[1-9])-?[0-9]{3}-?[0-9]{4}", ErrorMessage = "قالب {0} اشتباه است")]
        public string PhoneNumber { get; set; }



        [Display(Name = "ایمیل")]
        public string Email { get; set; }


        [Display(Name = "تاریخ تولد")]
        [Required(ErrorMessage = "لطفا تاریخ تولد خود را وارد کنید...")]
        public DateTime BirthDate { get; set; }
        public DateTime cratetiondate { get; set; }=DateTime.Now;


        [Display(Name = "آدرس")]
        public string Addres { get; set; }


        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا رمز عبور خود را وارد کنید...")]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "تعداد کاراکتر ها نباید کمتر از ۳ و بیشتر از ۱۲ باشد")]
        public string Password { get; set; }


        [Display(Name = "تکرار رمز عبور")]
        [Compare("Password", ErrorMessage = "تکرار رمز عبور صحیح نمیباشد...")]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "تعداد کاراکتر ها نباید کمتر از ۳ و بیشتر از ۱۲ باشد")]
        public string RePassword { get; set; }
        public bool IsAvalable { get; set; }

    }
}
