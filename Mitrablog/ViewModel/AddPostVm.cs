using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mitrablog.ViewModel
{
    public class AddPostVm
    {
        [Display(Name ="عنوان")]
        [Required (ErrorMessage ="لطفا فیلد عنوان را پر کنید")]
        public string Title { get; set; }
        [Display(Name = "متن")]
        [Required(ErrorMessage = "لطفا فیلد متن را پر کنید")]
        public string Content { get; set; }

    }
}
