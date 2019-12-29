using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Entities.Blog
{
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; } = "";
        public string Body { get; set; } = "";
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string Image { get; set; } = "";
        public string HeadLines { get; set; } = "";
        public string Description { get; set; }
        public string Tags { get; set; }
        public string Categories { get; set; }
        public List<MainComment> MainComments { get; set; }
        //author
        public string  AuthorName { get; set; }
        public string AuthorQuote { get; set; }

    }

}
