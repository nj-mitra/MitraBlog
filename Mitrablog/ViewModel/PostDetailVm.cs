using Mitrablog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mitrablog.ViewModel
{
    public class PostDetailVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public int Like { get; set; }
        public int DisLike { get; set; }
        public List<Comment> Comments { get; set; }
        public CommentCreateVm CommentVm { get; set; }
    }
}
