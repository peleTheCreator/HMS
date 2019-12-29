using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotelManagementSystem.Entities;
using HotelManagementSystem.ViewModel.api;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HotelManagementSystem.Services.api
{
    public interface IBookingService
    {
        Task<IReadOnlyCollection<Booking>> GetAllAsync(CancellationToken ct);

        Task<Booking> GetByIdAsync(string id, CancellationToken ct);

        Task UpdateAsync(Booking booking, CancellationToken ct);

        Task AddAsync(Booking group, CancellationToken ct);

        Task RemoveAsync(string id, CancellationToken ct);
        Task AddBookingAsync(Booking booking, string roomID, CancellationToken ct);
        void AddBookingApiAsync(Booking booking, string roomID);
        //Task<bool> CheckRoomAvaliabilityAsync(CheckBookingAvailableViewModel model, CancellationToken ct);
        Task<bool> CheckRoomAvaliabilityAsync(string RoomTypeID, CancellationToken ct);

    }
    public class BookingService : IBookingService   
    {
        private readonly AppDbContext context;
        private readonly ILogger logger;

        public BookingService(AppDbContext context,ILogger logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task AddAsync(Booking group, CancellationToken ct)
        {
           context.Bookings.Add(group);
           await  context.SaveChangesAsync(ct);
        }

        public async Task AddBookingAsync(Booking booking, string roomID, CancellationToken ct)
        {
            var room = await context.Rooms.SingleOrDefaultAsync(a => a.ID == roomID);

            room.Available = false;
            var updatedRoom = context.Rooms.Attach(room);
            updatedRoom.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            booking.TotalFee = room.Price;
            booking.Completed = true; 
            booking.Paid = true;
            room.Bookings.Add(booking);
           await  context.SaveChangesAsync();
        }
        public  void  AddBookingApiAsync(Booking booking, string roomID)
        {
                var room =  context.Rooms.FirstOrDefault(a => a.ID == roomID);
                room.Available = false;
                var updatedRoom = context.Rooms.Attach(room);
                updatedRoom.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                booking.TotalFee = room.Price;
                booking.Completed = true;
                booking.Paid = false;
                room.Bookings.Add(booking);
                context.SaveChanges();           
        }


        public async Task<bool> CheckRoomAvaliabilityAsync(string RoomTypeID, CancellationToken ct)
        {
            //get the rooms of the d specific roomtype and check available
            var check = await context.Rooms.
                Where(r => r.RoomTypeID == RoomTypeID && r.Available == true).AnyAsync(ct);
            return check;
        }


        public async  Task<IReadOnlyCollection<Booking>> GetAllAsync(CancellationToken ct)
        {
            return await context.Bookings.AsNoTracking().ToListAsync(ct);
        }

        public async  Task<Booking> GetByIdAsync(string id, CancellationToken ct)
        {
            return await context.Bookings.AsNoTracking().SingleOrDefaultAsync(ct);
        }

        public async Task RemoveAsync(string id, CancellationToken ct)
        {
            var book = await context.Bookings.SingleOrDefaultAsync(b => b.ID == id, ct);
            if(book != null)
            {
                context.Bookings.Remove(book);
                await context.SaveChangesAsync(ct);
            }
        }

        public async Task UpdateAsync(Booking booking, CancellationToken ct)
        {
          context.Bookings.Update(booking);
           await context.SaveChangesAsync(ct);
        }
    }
}
