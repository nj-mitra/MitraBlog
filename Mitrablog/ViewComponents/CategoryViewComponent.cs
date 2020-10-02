using Microsoft.AspNetCore.Mvc;
using Mitrablog.Models;
using Mitrablog.Models.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mitrablog.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using (var ctx = new ApplicationContext())
            {
                List<PostCategory> postCategories = ctx.PostCategories.ToList();
                return View(postCategories);
            }
        }
    }
}
