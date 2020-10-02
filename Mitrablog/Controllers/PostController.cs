using Microsoft.AspNetCore.Mvc;
using Mitrablog.Models;
using Mitrablog.Models.Posts;
using Mitrablog.ViewModel;

namespace Mitrablog.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Detail(int Id)
        {
            using (var ctx = new ApplicationContext())
            {
                Post post = ctx.Posts.Find(Id);
                //List<Comment> comments = ctx.Comments.Where(x => x.PostId == Id).ToList();
                PostDetailVm model = new PostDetailVm()
                {
                    Id = post.Id,
                    Title = post.Title,
                    Image = post.Image,
                    Like = post.Like,
                    DisLike = post.DisLike,
                    Content = post.Content,
                    //Comments = comments
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
        //[HttpPost]
        //public IActionResult Comment(PostDetailVm model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var ctx = new ApplicationContext())
        //        {
        //            var comment = new Comment()
        //            {
        //                PostId = 1,S
        //                Name = model.CommentVm.Name,
        //                Email = model.CommentVm.Email,
        //                Text = model.CommentVm.Text,
        //                Active = false
        //            };
        //            ctx.Comments.Add(comment);
        //            ctx.SaveChanges();
        //        }
        //    }
        //    return RedirectToAction("Detail");
        //}

    }
}