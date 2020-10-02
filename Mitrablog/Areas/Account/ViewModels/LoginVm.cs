using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mitrablog.Areas.Account.ViewModels
{
    public class LoginVm
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "وارد کردن فیلد نام کاربری الزامی است")]
        public string UserName { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "وارد کردن فیلد رمز عبور الزامی است")]
        public string Password { get; set; }
    }
}
