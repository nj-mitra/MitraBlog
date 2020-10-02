using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mitrablog.Models;
using Mitrablog.Models.Emails;
using Mitrablog.Models.Posts;
using Mitrablog.ViewModel;

namespace Mitrablog.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            using (var ctx = new ApplicationContext())
            {
                List<Post> posts = ctx.Posts.ToList();
                List<PostListVm> viewmodel = new List<PostListVm>();
                foreach (var post in posts)
                {
                    viewmodel.Add(new PostListVm
                    {
                        Id = post.Id,
                        Title = post.Title,
                        Image = post.Image,
                        Like = post.Like,
                        DisLike = post.DisLike
                    });
                }
                return View(viewmodel);
            }
        }

        [HttpPost]
        public IActionResult SendMail(string txtemail)
        {
            using (var ctx = new ApplicationContext())
            {
                if (!string.IsNullOrEmpty(txtemail))
                {
                    if (!ctx.Emails.Any(x => x.Mail == txtemail))
                    {
                        var email = new Email()
                        {
                            Mail = txtemail
                        };
                        ctx.Emails.Add(email);
                        ctx.SaveChanges();
                    }
                }
            }
            return RedirectToAction("Index");
        }

    }
}
