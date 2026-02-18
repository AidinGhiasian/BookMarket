using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using AccountManagement.Domain.RoleAgg;
using AM.Domain.Account.AD;

namespace AccountM.Application.Contracts.RoleApplication
{
    public class RoleViewModel
    {
        [Display(Name = "شناسه یکتا")]
        public long Id { get; set; }


        [Display(Name = "نام نقش")]
        [Required(ErrorMessage = "لطفا نام نقش  را وارد کنید...")]
        public string RoleName { get; set; }


        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا توضیحات خود را درباره نقش وارد کنید...")]
        public string Details { get; set; }
    }
}




