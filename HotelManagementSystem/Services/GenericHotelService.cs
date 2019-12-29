using HotelManagementSystem.Entities;
using HotelManagementSystem.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotelManagementSystem.Services
{
    public class GenericHotelService<TEntity> : IGenericHotelService<TEntity> where TEntity : class
    {
        private readonly AppDbContext context;
        private readonly IHostingEnvironment hostingEnvironment;
        protected DbSet<TEntity> DbSet;

        public GenericHotelService(AppDbContext context, IHostingEnvironment hostingEnvironment)
        {
            this.context = context;
            DbSet = context.Set<TEntity>();
            this.hostingEnvironment = hostingEnvironment;
        }

        public async Task<IEnumerable<TEntity>> GetAllItemsAsync()
        {
            return await DbSet.ToArrayAsync();
        }

        public async Task<TEntity> GetItemByIdAsync(string id)
        {
            if (id == null)
            {
                return null;
            }

            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> SearchFor(Expression<Func<TEntity, bool>> expression)
        {
            return await DbSet.Where(expression).ToArrayAsync();
        }

        public async Task CreateItemAsync(TEntity entity)
        {
            DbSet.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task EditItemAsync(TEntity entity)
        {
          
            context.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(TEntity entity)
        {
            DbSet.Remove(entity);
            await context.SaveChangesAsync();
        }

        public IEnumerable<Room> GetAllRooms()
        {
           return context.Rooms.Include(x => x.RoomType);
        }

        public RoomAdminIndexViewModel GetAllTheRoomAndRole()
        {
            return new RoomAdminIndexViewModel
            {
                Rooms = context.Rooms.ToList(),
                RoomTypes = context.RoomTypes.ToList()
            };
        }

        public async Task<RoomFeaturesAndImagesViewModel> GetRoomFeaturesAndImagesAsync(Room room)
        {
            var RoomImagesRelationship = context.ItemImageRelationships.Where(x => x.ItemID == room.ID);
            var images = new List<Image>();
            foreach (var RoomImage in RoomImagesRelationship)
            {
                var Image = await context.Images.FindAsync(RoomImage.ImageID);
                images.Add(Image);
            }
            var RoomFeaturesRelationship = context.RoomFeatureRelationships.Where(x => x.RoomID == room.ID);
            var features = new List<Feature>();
            foreach (var RoomFeature in RoomFeaturesRelationship)
            {
                var Feature = await context.Features.FindAsync(RoomFeature.FeatureID);
                features.Add(Feature);
            }

            var ImagesAndFeatures = new RoomFeaturesAndImagesViewModel
            {
                Images = images,
                Features = features
            };
            return ImagesAndFeatures;
        }

        public async Task<IEnumerable<RoomType>> GetAllRoomTypesAsync()
        {
            return await context.RoomTypes.ToArrayAsync();
        }

        public List<SelectedRoomFeatureViewModel> PopulateSelectedFeaturesForRoom(Room room)
        {
            var viewModel = new List<SelectedRoomFeatureViewModel>();
            var allFeatures = context.Features;
            if (room.ID == "" || room.ID == null)
            {
                foreach (var feature in allFeatures)
                {
                    viewModel.Add(new SelectedRoomFeatureViewModel
                    {
                        FeatureID = feature.ID,
                        Feature = feature,
                        Selected = false
                    });
                }
            }
            else
            {
                var roomFeatures = context.RoomFeatureRelationships.Where(x => x.RoomID == room.ID);
                var roomFeatureIDs = new HashSet<string>(roomFeatures.Select(x => x.FeatureID));


                foreach (var feature in allFeatures)
                {
                    viewModel.Add(new SelectedRoomFeatureViewModel
                    {
                        FeatureID = feature.ID,
                        Feature = feature,
                        Selected = roomFeatureIDs.Contains(feature.ID)
                    });
                }
            }

            return viewModel;
        }

        public void UpdateRoomFeaturesList(Room room, string[] SelectedFeatureIDs)
        {
            var PreviouslySelectedFeatures = context.RoomFeatureRelationships.Where(x => x.RoomID == room.ID);
            context.RoomFeatureRelationships.RemoveRange(PreviouslySelectedFeatures);
            context.SaveChanges();


            if (SelectedFeatureIDs != null)
            {
                foreach (var featureID in SelectedFeatureIDs)
                {
                    var AllFeatureIDs = new HashSet<string>(context.Features.Select(x => x.ID));
                    if (AllFeatureIDs.Contains(featureID))
                    {
                        context.RoomFeatureRelationships.Add(new RoomFeature
                        {
                            FeatureID = featureID,
                            RoomID = room.ID
                        });
                    }
                }
                context.SaveChanges();
            }
        }

        public void UpdateRoomImagesList(Room room, string[] imagesIDs)
        {
            var rum = room.ID;
            var PreviouslySelectedImages = context.ItemImageRelationships.Where(x => x.ItemID == room.ID);
            context.ItemImageRelationships.RemoveRange(PreviouslySelectedImages);
            context.SaveChanges();

            if (imagesIDs != null)
            {
                foreach (var imageID in imagesIDs)
                {
                    try
                    {
                        var AllImagesIDs = new HashSet<string>(context.Images.Select(x => x.ID));
                        if (AllImagesIDs.Contains(imageID))
                        {
                            context.ItemImageRelationships.Add(new ItemImage
                            {
                                ImageID = imageID,
                                ItemID = room.ID
                            });
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
                context.SaveChanges();
            }
        }

        public IEnumerable<Room> GetAllRoomsWithFeature(string featureID)
        {
            var RoomFeatures = context.RoomFeatureRelationships.Include(x => x.Room).Include(x => x.Room.RoomType).Where(x => x.FeatureID == featureID);
            var SelectedRooms = new List<Room>();
            foreach (var roomFeature in RoomFeatures)
            {
                SelectedRooms.Add(roomFeature.Room);
            }
            return SelectedRooms;
        }

        public async Task<AddImagesViewModel> AddImagesAsync(List<IFormFile> files)
        {
            var UploadErrors = new List<string>();
            var AddedImages = new List<Image>();
            var imagesFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");

            foreach (var formFile in files)
            {

                var _ext = Path.GetExtension(formFile.FileName).ToLower(); //file Extension

                if (formFile.Length > 0 && formFile.Length < 1000000)
                {
                    if (!(_ext == ".jpg" || _ext == ".png" || _ext == ".gif" || _ext == ".jpeg"))
                    {
                        UploadErrors.Add("The File \"" + formFile.FileName + "\" could Not be Uploaded because it has a bad extension --> \"" + _ext + "\"");
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
                    var image = new Image
                    {
                        ID = Guid.NewGuid().ToString(),
                        Name = NewFileName,
                        Size = files.Sum(f => f.Length).ToString(),
                        ImageUrl = "~/images/" + NewFileName,
                        FilePath = filePath,
                    };
                    AddedImages.Add(image);

                }
                else
                {
                    UploadErrors.Add(formFile.FileName + " Size is not Valid. -->(" + files.Sum(f => f.Length).ToString() + ")... Upload a file less than 1MB");
                }
            }
            context.Images.AddRange(AddedImages);
            context.SaveChanges();

            var result = new AddImagesViewModel
            {
                AddedImages = AddedImages,
                UploadErrors = UploadErrors
            };
            return result;
        }

        public async Task RemoveImageAsync(Image image)
        {
            File.Delete(image.FilePath);
            context.Images.Remove(image);
            await context.SaveChangesAsync();
        }

        public Room GetRoomByID(string roomID)
        {
            var room =  context.Rooms.Find(roomID);
           var roomtype = context.RoomTypes.Find(room.RoomTypeID);
            room.RoomType = roomtype;
            return room;
        }

        public bool GetBookingStatus(string v)
        {
          return  context.Bookings.Any(b => b.RoomID == v);
        }

        public void AddBookingForRoom(Booking booking, string roomID)
        {
            var tDays = (booking.CheckOut - booking.CheckIn).TotalDays;
            var TotaldaysBooked = (int)Math.Ceiling(tDays);

            var room = context.Rooms.FirstOrDefault(a => a.ID== roomID);
            room.Available = false;

            var updatedRoom = context.Rooms.Attach(room);
            updatedRoom.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            booking.TotalFee = room.Price * TotaldaysBooked;
            booking.Completed = true;
            booking.Room = room;
            booking.DateCreated = DateTime.Now;
            booking.Paid = true;
            room.Bookings.Add(booking);
             context.SaveChanges();               
        }
        public void UpdatBookingForRoom(Booking booking, string roomID)
        {
            var tDays = (booking.CheckOut - booking.CheckIn).TotalDays;
            var TotaldaysBooked = (int)Math.Ceiling(tDays);
            var room = context.Rooms.FirstOrDefault(a => a.ID == roomID);
            booking.TotalFee = room.Price * TotaldaysBooked;
            booking.Room = room;
            context.Bookings.Update(booking);
            context.SaveChanges();
        }
        public IEnumerable<Booking> GetAllBooking()
        {
            return context.Bookings.Include(b => b.Room);
        }

        public Booking GetBookingById(string id)
        {
           return context.Bookings.Include(B=>B.Room).ThenInclude(R=>R.RoomType).FirstOrDefault(b=>b.ID == id);
        }

        public IEnumerable<Image> GetAllImages()
        {
            return context.Images;
        }

        public bool RoomBookedCheckOutDate(string roomID)
        {
            var checkout =  context.Bookings.Where(b => b.RoomID == roomID).Select(r => r.CheckOut).FirstOrDefault();
            var room = context.Rooms.Where(rm => rm.ID == roomID).FirstOrDefault();
            if (checkout <= DateTime.Now)
            {
                room.Available = true;
                context.SaveChanges();
                return true;
            }
            else
            {
                room.Available = false;
                context.SaveChanges();
                return false;

            }
        }

      
    }
}
