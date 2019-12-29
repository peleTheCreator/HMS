using HotelManagementSystem.Entities;
using HotelManagementSystem.Entities.Blog;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Services.BlogServices
{
    public interface IFileManager
    {
        Task<string> SaveImage(List<IFormFile> image);
        FileStream ImageStream(string image);
        string GetImagePath(string image);
    }
    public class FileManager : IFileManager
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly AppDbContext context;
        private string _imagePath;
        public FileManager(IConfiguration configuration, IHostingEnvironment hostingEnvironment, AppDbContext context)
        {
            _imagePath = configuration["Path:Images"];
            this.hostingEnvironment = hostingEnvironment;
            this.context = context;
        }

        public string GetImagePath(string image)
        {
            var ogimagepath =  context.BlogImages
                .Where(img => img.ID == image)
                .Select(s => s.FilePath)
                .First();
            return ogimagepath;
        }

        public FileStream ImageStream(string image)
        {
            return new FileStream(Path.Combine(_imagePath, image), FileMode.Open, FileAccess.Read);
        }

        //public async Task<string> SaveImage(IFormFile image)
        //{
        //    try
        //    {

        //        var save_path = Path.Combine(_imagePath);
        //        if (!Directory.Exists(save_path))
        //        {
        //            Directory.CreateDirectory(save_path);
        //        }

        //        //internet explorer copys the whole file path
        //        var mime = image.FileName.Substring(image.FileName.LastIndexOf('.'));
        //        var filename = $"blogimg_{DateTime.Now.ToString("dd:MM:yy:HH:mm:ss")}{mime}";
        //        var filepath = save_path+"/"+filename;
        //        using (var filestream = new FileStream(filepath, FileMode.Create))
        //        {
        //            await image.CopyToAsync(filestream);
        //        }
        //        return filename;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        return "error";
        //    }
        //}

        public async Task<string> SaveImage(List<IFormFile> files)
        {
            var AddedImages = new List<BlogImage>();
            var imagesFolder = Path.Combine(hostingEnvironment.WebRootPath, "blogimages");

            foreach (var formFile in files)
            {

                var _ext = Path.GetExtension(formFile.FileName).ToLower(); //file Extension

                if (formFile.Length > 0 && formFile.Length < 1000000)
                {
                    if (!(_ext == ".jpg" || _ext == ".png" || _ext == ".gif" || _ext == ".jpeg"))
                    {
                        continue;
                    }

                    string NewFileName;
                    var ExistingFilePath = Path.Combine(imagesFolder, formFile.FileName);
                    var FileNameWithoutExtension = Path.GetFileNameWithoutExtension(formFile.FileName);

                    for (var count = 1; File.Exists(ExistingFilePath) == true; count++)
                    {
                        FileNameWithoutExtension = FileNameWithoutExtension + " (" + count.ToString() + ")";

                        var UpdatedFileName = FileNameWithoutExtension + _ext;
                        var UpdatedFilePath = Path.Combine(imagesFolder, UpdatedFileName);
                        ExistingFilePath = UpdatedFilePath;

                    }

                    NewFileName = FileNameWithoutExtension + _ext;
                    var filePath = Path.Combine(imagesFolder, NewFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                    var image = new BlogImage
                    {
                        ID = Guid.NewGuid().ToString(),
                        Name = NewFileName,
                        Size = files.Sum(f => f.Length).ToString(),
                        ImageUrl = "~/blogimages/" + NewFileName,
                        FilePath = filePath,
                    };
                    AddedImages.Add(image);
                }
            }
            context.BlogImages.AddRange(AddedImages);
            context.SaveChanges();
            var imageId = AddedImages.Select(r => r.ID).First();
            return imageId;
        }
    }
}

