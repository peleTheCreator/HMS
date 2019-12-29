using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotelBackEnd.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBackEnd.Services
{
    public interface IBookingService
    {
        Task<IReadOnlyCollection<Booking>> GetAllAsync(CancellationToken ct);

        Task<Booking> GetByIdAsync(string id, CancellationToken ct);

        Task UpdateAsync(Booking booking, CancellationToken ct);

        Task AddAsync(Booking group, CancellationToken ct);

        Task RemoveAsync(string id, CancellationToken ct);
    }
    public class BookingService : IBookingService
    {
        private readonly AppDbContext context;

        public BookingService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Booking group, CancellationToken ct)
        {
           context.Bookings.Add(group);
           await  context.SaveChangesAsync(ct);
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
