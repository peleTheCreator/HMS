using HotelManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagementSystem.ViewModel.api;
using System.Threading;
using System.Collections;
using Microsoft.AspNetCore.Identity.UI.Services;
using HotelManagementSystem.Controllers;
using HotelManagementSystem.ViewModel;

namespace HotelManagementSystem.Services.api
{
    public interface IRoomServices
    {
        Task<RandomImageFeaturesForRoomTypeViewModel> GetRandomRoomImagesForRoomTypeId(string roomTypeId, CancellationToken ct);
        DashBorard GetHotelAdminDashBord();
        Task<IEnumerable<string>> GetRoomFeatures(string roomTypeId, CancellationToken ct);
        Task<List<UserContact>> GetContactFormAsync();
        List<HotelDashBoardViewModel1> HotelDashBoard1();
        Task<IEnumerable<RoomType>> GetRoomRoomTypes(CancellationToken ct);
        SendRoomFeaturesToClientViewModel GetSendRoomFeature(string roomTypeId);
        List<HotelDashBoardViewModel2> HotelDashBoard2();
        Task<decimal> GetRoomTypesPrice(string roomTId, CancellationToken ct);
        void CreateContactFromForUser(UserContact contact);
        Task<string> GetAllImage(string ImageId, CancellationToken ct);
        List<HotelDashBoardViewModel3> HotelDashBoard3();
        Task<List<string>> GetAllImageIds(CancellationToken ct);
        bool SendEmailForRoomFeaturesAsync(string email, string RoomTypeId);
        Room GetAnyRoomAvailiableForRoomTypeID(string RoomTypeId);
        void CreateBookingForRoom(Booking booking, string roomID);
        Task UpdateContacToStausToReply(string contactId);
        Task<bool> CheckRoomAvaliabilityAsync(string roomTypeId, CancellationToken ct);
        Task<List<string>> GetRoomDescriptionForType(string roomTId, CancellationToken ct);
    }
    public class RoomServices : IRoomServices
    {
        private readonly AppDbContext Context;
        private readonly IEmailSender emailSender;
        private readonly IViewRenderService viewRender;
        private readonly INotificationRepository _notification;

        //now
        public static DateTime dateNow { get; } = DateTime.Now;
        public static DateTime ThedateEndDaynow { get; } = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 23, 59, 59);

        //week
        public static DateTime week { get; } = DateTime.Now.AddDays(-7);
        public static DateTime dateweekEnd { get; } = new DateTime(week.Year, week.Month, week.Day, 23, 59, 59);

        //month
        public static int Year { get; } = DateTime.Now.Year;
        public static int Month { get; } = DateTime.Now.Month;
        public static int daysmonth { get; } = DateTime.DaysInMonth(Year, Month);
        public static DateTime month { get; } = DateTime.Now.AddDays(-daysmonth).Date;
        public static DateTime datemonthEnd { get; } = new DateTime(week.Year, week.Month, week.Day, 23, 59, 59);

        public RoomServices(AppDbContext Context, IEmailSender emailSender, 
            IViewRenderService viewRender, INotificationRepository notification)
        {
            this.Context = Context;
            this.emailSender = emailSender;
            this.viewRender = viewRender;
            _notification = notification;
        }

        public void CreateContactFromForUser(UserContact contact)
        {
            Context.UserContacts.Add(contact);
            Context.SaveChanges();
        }
        public async  Task<List<UserContact>> GetContactFormAsync()
        {
           var query = await Context.UserContacts.ToListAsync();
            return query;
        }
        public async Task<string> GetAllImage(string ImageId, CancellationToken ct)
        {
            var ogimagepath = await Context.Images
                .Where(image => image.ID == ImageId)
                .Select(s => s.FilePath)
                .FirstOrDefaultAsync(ct);
            return ogimagepath;
        }

        public async Task<List<string>> GetAllImageIds(CancellationToken ct)
        {
            var query = await Context.Images.Select(img => img.ID).ToListAsync(ct);
            return query;
        }

        public async Task<RandomImageFeaturesForRoomTypeViewModel> GetRandomRoomImagesForRoomTypeId(string roomTypeId, CancellationToken ct)
        {
            //get any room with the specific roomtypeid : random random and random image;
            var queryroom = await Context.Rooms.Include(room => room.RoomImages)
                .Where(room => room.RoomTypeID == roomTypeId).ToListAsync(ct);
            Random r = new Random();
            Room randomRoomRoomType = new Room();
            int count = queryroom.Count();
            if (queryroom.Count() > 0)
            {
                randomRoomRoomType =  queryroom.ToList()[r.Next(0, count)];
            }
            else
            {
                randomRoomRoomType = queryroom.ToList().First();
            }

            var imageId= Context.ItemImageRelationships
                .Where(item => item.ItemID == randomRoomRoomType.ID).
                Select(i => i.ImageID).
                ToList();

            string imagepathId = "";
            int counter = queryroom.Count();
            if (imageId.Count() > 0)
            {
                imagepathId = imageId.ToList()[r.Next(0, counter)]; 
            }

            var ogimagepath =await Context.Images
                .Where(image => image.ID == imagepathId)
                .Select(s=>s.FilePath)
                .FirstOrDefaultAsync();
            var features =await Context.RoomFeatureRelationships
                .Where(rf => rf.RoomID == randomRoomRoomType.ID)
                .Select(feat => feat.FeatureID).ToListAsync(ct);
          
            return new RandomImageFeaturesForRoomTypeViewModel { Features = features, ImagePath = ogimagepath };
        }

        public async Task<IEnumerable<string>> GetRoomFeatures(string roomTypeId, CancellationToken ct)
        {
            // Context.RoomFeatureRelationships
            var queryroom = await Context.Rooms.Include(room => room.RoomImages)
              .Where(room => room.RoomTypeID == roomTypeId).ToListAsync(ct);
            Random r = new Random();
            Room randomRoomRoomType = new Room();
            int count = queryroom.Count();
            if (queryroom.Count() > 0)
            {
                randomRoomRoomType = queryroom.ToList()[r.Next(0, count)];
            }
            else
            {
                randomRoomRoomType = queryroom.ToList().First();
            }
            var queryroomfeature =await  Context.RoomFeatureRelationships
                .Where(f => f.RoomID == randomRoomRoomType.ID)
                .Select(rf=>rf.Feature.Name).ToListAsync(ct);
            return queryroomfeature;
        }

        public async Task<IEnumerable<RoomType>> GetRoomRoomTypes(CancellationToken ct)
        {
            var query =  await Context.RoomTypes.ToListAsync(ct);
            return query;
        }

        public async Task<decimal> GetRoomTypesPrice(string roomTId, CancellationToken ct)
        {
            var model = await Context.RoomTypes.
                Where(rt => rt.ID == roomTId)
                .Select(rt => rt.BasePrice).
                SingleOrDefaultAsync();
            return model;
        }

        public bool SendEmailForRoomFeaturesAsync(string email, string RoomTypeId)
        {
            var queryRoom =  Context.Rooms.Include(ft=>ft.Features).
                                    Where(rm => rm.RoomTypeID == RoomTypeId)
                                    .First();

            var imageId =  Context.ItemImageRelationships
                .Where(item => item.ItemID == queryRoom.ID).
                Select(i => i.ImageID).ToList()[0];

            var path = "https://localhost:44349/api/Room/image/"+imageId;
            var feats = Context.RoomFeatureRelationships.Where(rf => rf.RoomID == queryRoom.ID).Select(f=>f.Feature.Name);
            var model = new SendRoomFeaturesToClientViewModel();
            model.Path = path;
            model.Features = feats.ToList();
            model.Email = email;
            string message =  viewRender.RenderToStringAsync("SendRoomFeaturesToClientView/SendRoomFeaturesToClientView", model)
                .GetAwaiter().GetResult();
               emailSender.SendEmailAsync(email, "RoomFeature", message);
            return true;
        }

        public Room GetAnyRoomAvailiableForRoomTypeID(string RoomTypeId)
        {
            try
            {
                var AvailaibleRooms = new List<Room>();
                var room = Context.Rooms.
                    Where(rt => rt.RoomTypeID == RoomTypeId &&
                    rt.Available == true)
                    .ToList();
                if (room == null)
                {
                    return null;
                }
                Random r = new Random();
                int count = room.Count();
                var rmIndex = r.Next(0, count);
                var avaRoom = room[rmIndex];
                return avaRoom;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public void CreateBookingForRoom(Booking booking, string roomID)
        {
            var room = Context.Rooms.Include(rm=>rm.RoomType).FirstOrDefault(a => a.ID == roomID);
            room.Available = false;
            var updatedRoom = Context.Rooms.Attach(room);
            updatedRoom.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            booking.Completed = true;
            booking.Paid = false;           
            room.Bookings.Add(booking);
             Context.SaveChanges();

            var notification = new Notification
            {
                Text = $"room {room.Number} of Type {room.RoomType.Name}  was booked at {DateTime.Now.ToLocalTime()}",
            };

            _notification.Create(notification).GetAwaiter().GetResult();
        }

        public async Task UpdateContacToStausToReply(string contactId)
        {
            var contact = await Context.
                UserContacts.
                Where(uc => uc.UserContactId == contactId).
                FirstAsync();
            contact.Reply = true;
            Context.SaveChanges();
        }

        public async Task<bool> CheckRoomAvaliabilityAsync(string RoomTypeID, CancellationToken ct)
        {
            //get the rooms of the d specific roomtype and check available
            var check = await Context.Rooms.
                Where(r => r.RoomTypeID == RoomTypeID && r.Available == true).AnyAsync(ct);
            return check;
        }

        public SendRoomFeaturesToClientViewModel GetSendRoomFeature(string roomTypeId)
        {
            var query = Context.Rooms.
                          Include(rm => rm.Features).
                          Include(rm => rm.RoomImages).
                          Where(rm => rm.RoomTypeID == roomTypeId)
                         .ToList();
            var queryCount = query.Count();
            Random r = new Random();
            Room randomRoom = new Room();
            if (queryCount > 1)
                randomRoom = query.ToList()[r.Next(0, queryCount)];
            else
                randomRoom = query.ToList().First();

            var imageId = Context.ItemImageRelationships
                .Where(item => item.ItemID == randomRoom.ID).
                Select(i => i.ImageID).
                ToList();
            var path = "https://localhost:44349/api/Room/image/" + imageId;
            var model = new SendRoomFeaturesToClientViewModel();
            model.Features = randomRoom.Features.Select(rm => rm.Feature.Name).ToList();
            model.Path = path;
            return model;
        }

        public async Task<List<string>> GetRoomDescriptionForType(string roomTId, CancellationToken ct)
        {
            var query = await Context.Rooms.
                Where(rm => rm.RoomTypeID == roomTId).
                Select(r => r.RoomType.Description).
                ToListAsync(ct);
            return query;
        }

        public DashBorard GetHotelAdminDashBord()
        {
            var bokin = Context.Bookings.AsQueryable();

            var feeToday = bokin
                .Where(d => d.DateCreated >= dateNow.Date && d.DateCreated <= ThedateEndDaynow)
                .Select(s => s.TotalFee)
                .ToList();
            decimal totalFeeForToday = 0;
            foreach (var tf in feeToday)
            {
                totalFeeForToday = tf + totalFeeForToday;
            }

            var feeThisWeek = bokin
               .Where(d => d.DateCreated >= week.Date && d.DateCreated <= ThedateEndDaynow)
               .Select(s => s.TotalFee)
               .ToList();
            decimal totalFeeForThisWeek = 0;
            foreach (var tf in feeThisWeek)
            {
                totalFeeForThisWeek = tf + totalFeeForThisWeek;
            }

            var feeThisMonth = bokin
              .Where(d => d.DateCreated >= month.Date && d.DateCreated <= ThedateEndDaynow)
              .Select(s => s.TotalFee)
              .ToList();
            decimal totalFeeForThisMonth = 0;
            foreach (var tf in feeThisMonth)
            {
                totalFeeForThisMonth = tf + totalFeeForThisMonth;
            }

            var model = new DashBorard();
            model.TotalFeesForTheDay = totalFeeForToday;
            model.TotalRoomBookedForToday = feeToday.Count();
            model.TotalFeesForTheWeek = totalFeeForThisWeek;
            model.TotalRoomBookedForTheWeek = feeThisWeek.Count();
            model.TotalFeesForTheMonth = totalFeeForThisMonth;
            model.TotalRoomBookedForTheMonth = feeThisMonth.Count();
            return model;
        }

        public List<HotelDashBoardViewModel1> HotelDashBoard1()
        {
            var model = new List<HotelDashBoardViewModel1>();
            var rooms = Context.Rooms.Include(r=>r.RoomType).ToList();
            var bokin = Context
                .Bookings.
                Where(d => d.DateCreated >= dateNow.Date && d.DateCreated <= ThedateEndDaynow)
                .AsQueryable();
            foreach (var rm in rooms)
            {
                var TrmBk = bokin.Where(b => b.RoomID == rm.ID).ToList().Count();
                var rmTyp = rm.RoomType.Name;
                var rmNum = rm.Number;
                model.Add(new HotelDashBoardViewModel1 {
                    room = $"Rm{rmNum} {rmTyp}",
                    totalPerRoomBookedForTheDay = TrmBk
                });
            }
            return model;
        }

        public List<HotelDashBoardViewModel2> HotelDashBoard2()
        {
            var model = new List<HotelDashBoardViewModel2>();
            var rooms = Context.Rooms.Include(r => r.RoomType).ToList();
            var bokin = Context
                .Bookings.
                Where(d => d.DateCreated >= week.Date && d.DateCreated <= ThedateEndDaynow)
                .AsQueryable();
            foreach (var rm in rooms)
            {
                var TrmBk = bokin.Where(b => b.RoomID == rm.ID).ToList().Count();
                var rmTyp = rm.RoomType.Name;
                var rmNum = rm.Number;
                model.Add(new HotelDashBoardViewModel2
                {
                    room = $"Rm{rmNum} rmTyp",
                    totalPerRoomBookedForTheWeek = TrmBk
                });
            }
            return model;
        }

        public List<HotelDashBoardViewModel3> HotelDashBoard3()
        {
            var model = new List<HotelDashBoardViewModel3>();
            var rooms = Context.Rooms.Include(r => r.RoomType).ToList();
            var bokin = Context
                .Bookings.
                Where(d => d.DateCreated >= month.Date && d.DateCreated <= ThedateEndDaynow)
                .AsQueryable();
            foreach (var rm in rooms)
            {
                var TrmBk = bokin.Where(b => b.RoomID == rm.ID).ToList().Count();
                var rmTyp = rm.RoomType.Name;
                var rmNum = rm.Number;
                model.Add(new HotelDashBoardViewModel3
                {
                    room = $"Rm{rmNum} rmTyp",
                    totalPerRoomBookedForMonth = TrmBk
                });
            }
            return model;
        }
    }
}
