 
using HotelManagementSystem.Entities.Blog;
using HotelManagementSystem.Services.BlogServices;
using HotelManagementSystem.ViewModel.Blog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers.BlogControllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly IBlogResprository blogResprository;
        private readonly IFileManager fileManager;

        public BlogController(IBlogResprository blogResprository,IFileManager fileManager)
        {
            this.blogResprository = blogResprository;
            this.fileManager = fileManager;
        }

        public IActionResult Index(string Category="", int pagenumber = 0, string search="")
        {
            if(pagenumber <= 0)
            {
                return RedirectToAction("Index", new{ pagenumber = 1, Category });
            }
            BlogIndexViewModel model = new BlogIndexViewModel();
            //var posts = string.IsNullOrEmpty(Category) ? 
            //    blogResprository.GetAllPost() :
            //    blogResprository.GetAllPost(Category); 
             var category = blogResprository.GetAllCategories();
              var tag = blogResprository.GetAllTags();
            IndexViewModel postmodel = blogResprository.GetAllPost(Category, pagenumber, search);
            //if (pagenumber > postmodel.)
            //{
            //    return RedirectToAction("Index", new { pagenumber = 1, Category });
            //}
            model.Postmodel = postmodel;
            model.Categories = category;
            model.Tags = tag;          
            return View(model);
        }


        public IActionResult Post(int id)
        {

            var post = blogResprository.GetPost(id);
            if(post == null)
            {
                return RedirectToAction("Index", "Blog");
            }
            BlogPostViewModel model = new BlogPostViewModel();
            List<CommentViewModel> Postcomments = blogResprository.Postcomments(id);
            int PostCommentCount = blogResprository.PostCommentCount(id);
            model.Comment = Postcomments;
            model.Post = post;
            return View(model);
        }

        [HttpPost()]
        public async Task<IActionResult> Comment(string Email, string Name, string Message, string MainCommentId,string PostId)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Post", new { id = int.Parse(PostId) });
            var post = blogResprository.GetPost(int.Parse(PostId));
            if(int.Parse(MainCommentId) == 0)
            {
                post.MainComments = post.MainComments ?? new List<MainComment>();
                post.MainComments.Add(new MainComment {
                    Message = Message,
                    Created = DateTime.Now,
                    Email = Email,
                    Name = Name,                    
                });
                blogResprository.UpdatePost(post);
            }
            else
            {
                var subcomment = new SubComment
                {
                    MainCommentId = int.Parse(MainCommentId),
                    Created = DateTime.Now,
                    Message=Message,
                    Email = Email,
                    Name = Email,
                };
                blogResprository.AddSubComment(subcomment);
            }
            await blogResprository.SaveChangesAsync();

            return RedirectToAction("Post", new { id = PostId });
        }

        public IActionResult Home()
        {
            return Redirect("https://localhost:44320/Home/Index");
        }

        public IActionResult Room()
        {
            return Redirect("https://localhost:44320/Room/Index");
        }
        public IActionResult Contact()
        {
            return Redirect("https://localhost:44320/Contact/Index");

        }
        public IActionResult Photo()
        {
            return Redirect("https://localhost:44320/Image/Index");
        }
    }
    [AllowAnonymous]
    [Route("api/FileManager")]
    public class FileManagerController : Controller
    {
        private readonly IFileManager fileManager;

        public FileManagerController(IFileManager fileManager)
        {
            this.fileManager = fileManager;
        }

        [HttpGet("{image}")]
        public IActionResult Image(string image)
        {
          var path =   fileManager.GetImagePath(image);
            var Image = System.IO.File.OpenRead(path);
            var mime = path.Substring(path.LastIndexOf(".") + 1);
            return File(Image, $"image/{mime}");
            //return new FileStreamResult(fileManager.ImageStream(image), $"image/{mime}");
        }
    }
}
