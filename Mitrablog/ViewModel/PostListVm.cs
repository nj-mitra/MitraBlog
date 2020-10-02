using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mitrablog.ViewModel
{
    public class PostListVm
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int Like { get; set; }
        public int DisLike { get; set; }
    }
}
