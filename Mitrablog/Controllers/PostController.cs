using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mitrablog.Models;
using Mitrablog.Models.Posts;
using Mitrablog.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Mitrablog.Controllers
{
    public class PostController : Controller
    {
        public IActionResult List(int CategoryId)
        {
            using (var ctx = new ApplicationContext())
            {
                List<Post> posts = ctx.Posts.Where(x=>x.PostCategoryId==CategoryId).ToList();
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

        public IActionResult Detail(int Id)
        {
            using (var ctx = new ApplicationContext())
            {
                Post post = ctx.Posts.Find(Id);
                List<Comment> comments = ctx.Comments.Where(x => x.PostId == Id && x.Active == true).ToList();
                PostDetailVm model = new PostDetailVm()
                {
                    Id = post.Id,
                    Title = post.Title,
                    Image = post.Image,
                    Like = post.Like,
                    DisLike = post.DisLike,
                    Content = post.Content,
                    Comments = comments
                };
                return View(model);
            }
        }
        [HttpPost]
        public IActionResult LikePost(int Id)
        {
            using (var ctx = new ApplicationContext())
            {
                Post post = ctx.Posts.Find(Id);
                post.Like++;
                ctx.SaveChanges();
                return RedirectToAction("Detail", new { Id = post.Id });
            }
        }

        [HttpPost]
        public IActionResult DislikePost(int Id)
        {
            using (var ctx = new ApplicationContext())
            {
                Post post = ctx.Posts.Find(Id);
                post.DisLike++;
                ctx.SaveChanges();
                return RedirectToAction("Detail", new { Id = post.Id });
            }
        }
        [HttpPost]
        public IActionResult Comment(PostDetailVm model)
        {
            if (ModelState.IsValid)
            {
                using (var ctx = new ApplicationContext())
                {
                    var comment = new Comment()
                    {
                        PostId = model.Id,
                        Name = model.CommentVm.Name,
                        Email = model.CommentVm.Email,
                        Text = model.CommentVm.Text,
                        Active = false
                    };
                    ctx.Comments.Add(comment);
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Detail", new { Id = model.Id });
        }

    }
}