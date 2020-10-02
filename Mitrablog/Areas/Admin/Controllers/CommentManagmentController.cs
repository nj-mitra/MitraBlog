using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mitrablog.Areas.Admin.ViewModel;
using Mitrablog.Models;
using System.Collections.Generic;
using System.Linq;


namespace Mitrablog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CommentManagmentController : Controller
    {
        public IActionResult List()
        {

            using (var ctx = new ApplicationContext())
            {
                List<Comment> comments = ctx.Comments.Where(x => x.Active == false).ToList();
                List<CommentListManagerVm> viewmodel = new List<CommentListManagerVm>();
                foreach (var item in comments)
                {
                    viewmodel.Add(new CommentListManagerVm
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Email = item.Email
                    });
                }
                return View(viewmodel);
            }
        }
        public IActionResult Accept(int Id)
        {
            using (var ctx = new ApplicationContext())
            {
                var comment = ctx.Comments.Find(Id);
                comment.Active = true;
                ctx.SaveChanges();
                return RedirectToAction("List");
            }
        }
        public IActionResult Reject(int Id)
        {
            using (var ctx = new ApplicationContext())
            {
                var comment = ctx.Comments.Find(Id);
                ctx.Comments.Remove(comment);
                ctx.SaveChanges();

                return RedirectToAction("List");
            }
        }
    }
}
