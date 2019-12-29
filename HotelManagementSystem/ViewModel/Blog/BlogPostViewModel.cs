using HotelManagementSystem.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.ViewModel.Blog
{
    public class BlogPostViewModel
    {
        public Post Post { get; set; }
        public int TotalComment { get; set; }
        public List<CommentViewModel> Comment { get; set; } = new List<CommentViewModel>();
    }
}
