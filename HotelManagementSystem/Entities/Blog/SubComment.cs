using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Entities.Blog
{
    public class SubComment : Comment
    {
        public int MainCommentId { get; set; }
    }
}
