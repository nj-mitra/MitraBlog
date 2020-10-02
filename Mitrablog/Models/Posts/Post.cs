using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mitrablog.Models.Posts
{
    public class Post
    {
        public int Id { get; set; }
        public int PostCategoryId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public int Like { get; set; }
        public int DisLike { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
