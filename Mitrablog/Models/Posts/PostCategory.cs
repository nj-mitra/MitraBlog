using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mitrablog.Models.Posts
{
    public class PostCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Post> Posts { get; set; }
    }
}
