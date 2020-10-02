using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mitrablog.ViewModel
{
    public class CommentCreateVm
    {

        [Display(Name = "نام")]
        [Required(ErrorMessage = "وارد کردن فیلد نام الزامی است")]
        public string Name { get; set; }

        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمیباشد")]
        [Required(ErrorMessage = "وارد کردن فیلد ایمیل الزامی است")]
        public string Email { get; set; }

        [Display(Name = "نظر")]
        [Required(ErrorMessage = "وارد کردن فیلد نظر الزامی است")]
        public string Text { get; set; }
    }
}
