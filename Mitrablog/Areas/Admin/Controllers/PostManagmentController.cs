using Microsoft.AspNetCore.Mvc;
using Mitrablog.Areas.Admin.ViewModel;
using Mitrablog.Models;
using Mitrablog.Models.Posts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mitrablog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostManagmentController : Controller
    {
        public IActionResult List()
        {
            using (var ctx = new ApplicationContext())
            {
                List<Post> posts = ctx.Posts.OrderByDescending(x => x.Id).ToList();
                List<PostListManagerVm> viewmodel = new List<PostListManagerVm>();
                foreach (var post in posts)
                {
                    viewmodel.Add(new PostListManagerVm
                    {
                        Id = post.Id,
                        Title = post.Title,
                    });
                }
                return View(viewmodel);
            }
        }

        public IActionResult Create()
        {
            using (var ctx = new ApplicationContext())
            {
                List<PostCategory> postCategories = ctx.PostCategories.ToList();
                AddPostVm viewmodel = new AddPostVm();
                viewmodel.Categories = postCategories;
                return View(viewmodel);
            }
        }

        [HttpPost]
        public IActionResult Create(AddPostVm viewmodel)
        {
            if (ModelState.IsValid)
            {
                using (var ctx = new ApplicationContext())
                {
                    var post = new Post()
                    {
                        Title = viewmodel.Title,
                        Content = viewmodel.Content,
                        PostCategoryId = viewmodel.PostCategoryId
                    };
                    if (viewmodel?.Image?.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            viewmodel.Image.CopyTo(ms);
                            var fileByte = ms.ToArray();
                            post.Image = Convert.ToBase64String(fileByte);
                        }
                    }
                    ctx.Posts.Add(post);
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("List", "PostManagment");
        }
    }
}
