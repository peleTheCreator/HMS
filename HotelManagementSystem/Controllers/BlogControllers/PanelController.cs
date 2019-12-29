using HotelManagementSystem.Entities.Blog;
using HotelManagementSystem.Services.BlogServices;
using HotelManagementSystem.ViewModel.Blog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers.BlogControllers
{
    [Authorize(Roles = "Admin,Blogger")]
    public class BlogPanelController : Controller
    {
        private readonly IBlogResprository blogResprository;
        private readonly IFileManager fileManager;

        public BlogPanelController(IBlogResprository blogResprository,IFileManager fileManager)
        {
            this.blogResprository = blogResprository;
            this.fileManager = fileManager;
        }

        public IActionResult Index()
        {
            var posts = blogResprository.GetAllPost();
            return View(posts);
        }
        [HttpGet()]
        public IActionResult Edit(int? id)
        {
            //to create and edit post
            if (id == null)
            {
                return View(new PostViewModel());
            }
            else
            {
                var post = blogResprository.GetPost((int)id);
                return View(new PostViewModel {
                    Id = post.Id,
                    Title = post.Title,
                    HeadLines = post.HeadLines,
                    Body = post.Body,
                    Name=post.Name,
                    CurrrentImage =post.Image,
                    Tags = post.Tags,
                    Categories = post.Categories,
                    Description = post.Description,
                   AuthorName = post.AuthorName,
                   AuthorQuote =post.AuthorQuote
                });
            }
        }
        [HttpPost()]
        public async Task<IActionResult> Edit(PostViewModel vm)
        {
            var post = new Post
            {
                Id = vm.Id,
                Title = vm.Title,
                HeadLines=vm.HeadLines,
                Body = vm.Body,
                Name=vm.Name,
                Tags =vm.Tags,
                Categories = vm.Categories,
                Description = vm.Description,
                AuthorName = vm.AuthorName,
                AuthorQuote = vm.AuthorQuote
            };
            if (vm.Image == null)
                post.Image = vm.CurrrentImage;
            else
                post.Image = await fileManager.SaveImage(vm.Image);

            if (post.Id > 0)
                blogResprository.UpdatePost(post);
            else
                blogResprository.AddPost(post);
            if (await blogResprository.SaveChangesAsync())
            {
                return RedirectToAction("Index");
            }
            return View(post);
        }

        [HttpGet()]
        public async Task<IActionResult> Remove(int id)
        {
            blogResprository.RemovePost(id);
            await blogResprository.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
