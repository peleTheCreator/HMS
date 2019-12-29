using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.ViewModel.Blog
{
    public class CommentViewModel
    {
        [Required]
        public int PostId { get; set; }
        public int MainCommentId { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public DateTime DateTime { get; set; }
    }
}
