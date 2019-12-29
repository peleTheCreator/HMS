using HotelManagementSystem.Entities;
using HotelManagementSystem.Entities.Blog;
using HotelManagementSystem.ViewModel.Blog;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Services.BlogServices
{
    public interface IBlogResprository
    {
        Post GetPost(int id);
        List<Post> GetAllPost();
        void AddPost(Post post);
        void UpdatePost(Post post);
        void RemovePost(int id);
        Task<bool> SaveChangesAsync();
        List<Categories> GetAllCategories();
        List<Post> GetAllPost(string Category);
        IndexViewModel GetAllPost(string Category, int pagenumber, string search);
        List<string> GetAllTags();
        List<CommentViewModel> Postcomments(int id);
        int PostCommentCount(int id);
        void AddSubComment(SubComment subcomment);
    }
    public class BlogResprository : IBlogResprository
    {
        private readonly AppDbContext context;

        public BlogResprository(AppDbContext Context)
        {
            context = Context;
        }

        public void AddPost(Post post)
        {
            context.Posts.Add(post);
        }

        public List<Post> GetAllPost()
        {
            return context.Posts.Include(p=>p.MainComments).ToList();
        }
        public List<Post> GetAllPost(string Category)
        {
            return context.Posts.Where(p=>p.Categories.ToLower().Equals(Category.ToLower())).ToList();
        }

        public Post GetPost(int id)
        {
            return context.Posts.
                Include(p=>p.MainComments)
                .ThenInclude(p=>p.SubComments).
                FirstOrDefault(p => p.Id == id);
        }

        public void RemovePost(int id)
        {
            context.Posts.Remove(GetPost(id));
        }


        public void UpdatePost(Post post)
        {
            context.Posts.Update(post);
        }

        public async Task<bool> SaveChangesAsync()
        {
            if(await context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public List<Categories> GetAllCategories()
        {
            var categories = new List<Categories>();
            var Modelcategories = new List<Categories>();

            var cats = context.Posts.Select(c => c.Categories).Distinct().ToList();
            for (int i = 0; i < cats.Count(); i++)
            {
                var catCount = context.Posts
                    .Where(p => p.Categories == cats[i]).
                    Count();
                categories.Add(new Categories { Category = cats[i], CategoryCount = catCount.ToString() });
            }

            return categories;
        }

        public List<string> GetAllTags()
        {
            var tags = context.Posts.Select(P => P.Tags).ToList();
            return tags;
        }

        public List<CommentViewModel> Postcomments(int id)
        {
            var model = new List<CommentViewModel>();
            var comments = context
                .Posts.
                Include(p => p.MainComments).
                ThenInclude(p => p.SubComments).
                FirstOrDefault(p=>p.Id==id);
              if(comments == null)
              {
                return model;
              }  
            foreach(var comm in comments.MainComments)
            {
                model.Add(new CommentViewModel
                {
                    DateTime = comm.Created,
                    Email = comm.Email,
                    MainCommentId = comm.Id,
                    PostId = id,
                    Message = comm.Message,
                    Name = comm.Name
                });
            }
            return model;
        }

        public int PostCommentCount(int id)
        {
            var count = context
                .Posts.
                Include(p => p.MainComments).
                Where(p => p.Id == id).
                ToList().Count();
            return count;
        }

        public void AddSubComment(SubComment subcomment)
        {
            context.SubComments.Add(subcomment);
        }

        public IndexViewModel GetAllPost(string Category, int pagenumber,
            string search)
        {
            int pageSize = 2;
            int skipAmount = pageSize * (pagenumber - 1);
            var query = context.Posts.Include(p=>p.MainComments)
                .ThenInclude(p=>p.SubComments).AsNoTracking() //use asnotracking if you dont wanna edit the objects
                .AsQueryable();

            if (!string.IsNullOrEmpty(Category))
                query = query.Where(c => c.Categories.ToLower().Equals(Category.ToLower()));

            if (!string.IsNullOrEmpty(search))
            {
                //1 query = query.Where(x => (x.Title + x.Body + x.Description).Contains(search));
                //2  query = query.Where(x =>x.Title.Contains(search) || x.Body.Contains(search) || x.Description.Contains(search));
                //for performance use the third one cos the 2 is expensive if they os a lot of post
                query = query.Where(x => EF.Functions.Like(x.Title, $"%{search}%")
                                || EF.Functions.Like(x.Body, $"%{search}%")
                                || EF.Functions.Like(x.Description, $"%{search}%")
                                  );  
            }

            int postcount = query.Count();
            int capacity = skipAmount + pageSize;
            return new IndexViewModel
            {
                PageNumber = pagenumber,
                PageCount= (int)Math.Ceiling((double)postcount/ pageSize),
                CanGoNext = postcount>skipAmount+pageSize,
                Category = Category,
                search=search,
                Post = query.Skip(skipAmount).Take(pageSize).ToList()
            };
        }
    }
}
