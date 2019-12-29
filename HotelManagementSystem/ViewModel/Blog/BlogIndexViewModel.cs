using HotelManagementSystem.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.ViewModel.Blog
{

    public class Categories
    {
        public string Category { get; set; }
        public string CategoryCount { get; set; }
    }

    public class BlogIndexViewModel
    {
        public List<Categories> Categories { get; set; } = new List<Categories>();
        public List<string> Tags { get; set; } = new List<string>();
        public  int CommentCount { get; set; }
        public List<CategoryPerPost> CategoryPerPosts { get; set; }

        public IndexViewModel Postmodel { get; set; }
    }
    public class CategoryPerPost
    {
        public string Post { get; set; }
        public string  Category { get; set; }
    }
    public class IndexViewModel
    {
        public List<Post> Post { get; set; } = new List<Post>();
        public int PageCount { get; set; }
        public int PageNumber { get; set; }
        public string Category { get; set; }
        public bool CanGoNext { get; set; }
        public string search { get; set; }
    }
}
