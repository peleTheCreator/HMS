using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Entities.Blog
{
    public class MainComment : Comment
    {
        public List<SubComment> SubComments { get; set; }
    }
}
