using HotelManagementSystem.Entities.Blog;
using HotelManagementSystem.Entities.InventotyEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Entities
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<RoomFeature> RoomFeatureRelationships { get; set; }
        public DbSet<ItemImage> ItemImageRelationships { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }
        //  public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<ProductPurchaseOrderTracking> ProductPurchaseOrderTracking { get; set; }
       // public DbSet<ProductPurchaseOrderTrack> ProductPurchaseOrderTracks { get; set; }

        //notification
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationApplicationUser> UserNotifications { get; set; }


        //blogging
        public DbSet<Post> Posts { get; set; }
        public DbSet<MainComment> MainComments { get; set; }
        public DbSet<SubComment> SubComments { get; set; }
        public DbSet<BlogImage> BlogImages { get; set; }

        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<RoomFeature>()
                .HasKey(x => new { x.RoomID, x.FeatureID });

            builder.Entity<RoomFeature>()
                .HasOne(rf => rf.Room)
                .WithMany(r => r.Features);

            builder.Entity<RoomFeature>()
                .HasOne(f => f.Feature)
                .WithMany(r => r.Rooms);

            builder.Entity<ItemImage>()
                .HasKey(x => new { x.ItemID, x.ImageID });

            builder.Entity<RoomType>()
                .HasMany(b => b.Rooms)
                .WithOne(p => p.RoomType)
                .HasForeignKey(p => p.RoomTypeID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Vendor>()
                .HasMany(v => v.Products)
                .WithOne(v => v.Vendor);

            builder.Entity<NotificationApplicationUser>()
                           .HasKey(k => new { k.NotificationId, k.ApplicationUserId });
        }
    }
}

