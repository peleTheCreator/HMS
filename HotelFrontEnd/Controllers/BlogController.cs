using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFrontEnd.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult GoBlogging()
        {
            return Redirect("https://localhost:44349/Blog/Index");
        }
    }
}
