using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mitrablog.Models;
using Mitrablog.ViewModel;

namespace Mitrablog.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Create()
        {
            return View();
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
                        content = viewmodel.Content,
                        //CategoryId = viewmodel.CategoryId
                    };
                    //if (viewmodel?.Image?.Length > 0)
                    //{
                    //    using (var ms = new MemoryStream())
                    //    {
                    //        viewmodel.Image.CopyTo(ms);
                    //        var fileByte = ms.ToArray();
                    //        post.Image = Convert.ToBase64String(fileByte);
                    //    }
                    ctx.Posts.Add(post);
                    ctx.SaveChanges();
                }
                
            }
            return View(viewmodel);
        }
    }
}