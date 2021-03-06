﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mitrablog.Areas.Admin.ViewModel
{
    public class CategoryCreateVm
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "وارد کردن فیلد عنوان الزامی است")]
        public string Title { get; set; }
    }
}
