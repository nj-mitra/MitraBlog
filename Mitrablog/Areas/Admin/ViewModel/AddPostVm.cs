using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mitrablog.Models.Posts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Mitrablog.Areas.Admin.ViewModel
{
    public class AddPostVm
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "وارد کردن فیلد عنوان الزامی است")]
        public string Title { get; set; }

        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = "وارد کردن فیلد دسته بندی الزامی است")]
        public int PostCategoryId { get; set; }

        [Display(Name = "عکس")]
        public IFormFile Image { get; set; }

        [Display(Name = "متن پست")]
        public string Content { get; set; }

        public List<PostCategory> Categories { get; set; }

        public List<SelectListItem> GetCategoriesListItem()
        {
            var result = Categories.Select(c => new SelectListItem
            {
                Text = c.Title,
                Value = c.Id.ToString()
            }).ToList();
            result.Insert(0, new SelectListItem(string.Empty, string.Empty));
            return result;
        }

    }
}
