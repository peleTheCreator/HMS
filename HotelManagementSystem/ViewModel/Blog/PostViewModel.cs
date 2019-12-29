using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.ViewModel.Blog
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Name { get; set; }
        public string DateCreated { get; set; }
        public List<IFormFile> Image { get; set; } = new List<IFormFile>();
        public string HeadLines { get; set; }
        public string CurrrentImage { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public string Categories { get; set; }
        public string AuthorName { get; set; }
        public string AuthorQuote { get; set; }
    }

}
