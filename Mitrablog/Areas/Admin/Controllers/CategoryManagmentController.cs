using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mitrablog.Areas.Admin.ViewModel;
using Mitrablog.Models;
using Mitrablog.Models.Posts;

namespace Mitrablog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryManagmentController : Controller
    {
        public IActionResult List()
        {

            using (var ctx = new ApplicationContext())
            {
                List<PostCategory> postCategories = ctx.PostCategories.ToList();
                List<CategoryListManagerVm> viewmodel = new List<CategoryListManagerVm>();
                foreach (var cat in postCategories)
                {
                    viewmodel.Add(new CategoryListManagerVm
                    {
                        Id = cat.Id,
                        Title = cat.Title,
                    });
                }
                return View(viewmodel);
            }

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryCreateVm viewmodel)
        {
            if (ModelState.IsValid)
            {
                using (var ctx = new ApplicationContext())
                {
                    var category = new PostCategory()
                    {
                        Title = viewmodel.Title
                    };
                    ctx.PostCategories.Add(category);
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("List", "CategoryManagment");
        }
    }
}
