﻿// <auto-generated />
using System;
using HotelManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotelManagementSystem.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HotelManagementSystem.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.Blog.BlogImage", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FilePath");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name");

                    b.Property<string>("Size");

                    b.HasKey("ID");

                    b.ToTable("BlogImages");
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.Blog.MainComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<string>("Email");

                    b.Property<string>("Message");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("PostId");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("MainComments");
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.Blog.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorName");

                    b.Property<string>("AuthorQuote");

                    b.Property<string>("Body");

                    b.Property<string>("Categories");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Description");

                    b.Property<string>("HeadLines");

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.Property<string>("Tags");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.Blog.SubComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<string>("Email");

                    b.Property<int>("MainCommentId");

                    b.Property<string>("Message");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("MainCommentId");

                    b.ToTable("SubComments");
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.Booking", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<DateTime>("CheckIn");

                    b.Property<DateTime>("CheckOut");

                    b.Property<bool>("Completed");

                    b.Property<string>("CustomerAddress");

                    b.Property<string>("CustomerCity");

                    b.Property<string>("CustomerEmail");

                    b.Property<string>("CustomerName")
                        .IsRequired();

                    b.Property<string>("CustomerPhone");

                    b.Property<DateTime>("DateCreated");

                    b.Property<int>("Guests");

                    b.Property<string>("OtherRequests");

                    b.Property<bool>("Paid");

                    b.Property<string>("RoomID");

                    b.Property<decimal>("TotalFee");

                    b.HasKey("ID");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("RoomID");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.Feature", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Icon");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.Image", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FilePath");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name");

                    b.Property<string>("RoomID");

                    b.Property<string>("Size");

                    b.HasKey("ID");

                    b.HasIndex("RoomID");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.InventotyEntities.Product", b =>
                {
                    b.Property<string>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("CostPrice");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("PriceSell");

                    b.Property<string>("VendorId");

                    b.HasKey("ProductId");

                    b.HasIndex("VendorId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.InventotyEntities.ProductPurchaseOrderTracking", b =>
                {
                    b.Property<int>("ProductPurchaseOrderTrackerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("ProductId");

                    b.Property<string>("PurchaseOrderId");

                    b.Property<int>("RemainingProductQty");

                    b.Property<int>("TotalPoductQty");

                    b.HasKey("ProductPurchaseOrderTrackerId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductPurchaseOrderTracking");
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.InventotyEntities.PurchaseOrder", b =>
                {
                    b.Property<string>("PurchaseOrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("CostOfOne");

                    b.Property<string>("Number");

                    b.Property<string>("ProductId");

                    b.Property<DateTime>("PurchaseOrderDate");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("TotalCost");

                    b.HasKey("PurchaseOrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("PurchaseOrders");
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.InventotyEntities.SalesOrder", b =>
                {
                    b.Property<string>("SalesOrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Price");

                    b.Property<string>("ProductId");

                    b.Property<int>("Sale");

                    b.Property<DateTime>("SalesDate");

                    b.Property<int>("TotalSales");

                    b.HasKey("SalesOrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("SalesOrders");
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.InventotyEntities.Vendor", b =>
                {
                    b.Property<string>("VendorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Address2");

                    b.Property<string>("Description");

                    b.Property<string>("Email");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.HasKey("VendorId");

                    b.ToTable("Vendors");
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.ItemImage", b =>
                {
                    b.Property<string>("ItemID");

                    b.Property<string>("ImageID");

                    b.HasKey("ItemID", "ImageID");

                    b.HasIndex("ImageID");

                    b.ToTable("ItemImageRelationships");
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.NotificationApplicationUser", b =>
                {
                    b.Property<int>("NotificationId");

                    b.Property<string>("ApplicationUserId");

                    b.Property<bool>("IsRead");

                    b.HasKey("NotificationId", "ApplicationUserId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("UserNotifications");
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.Review", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("ReviewerEmail");

                    b.Property<string>("ReviewerName");

                    b.Property<string>("RoomID");

                    b.HasKey("ID");

                    b.HasIndex("RoomID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.Room", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Available");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("MaximumGuests");

                    b.Property<int>("Number");

                    b.Property<decimal>("Price");

                    b.Property<string>("RoomTypeID");

                    b.HasKey("ID");

                    b.HasIndex("RoomTypeID");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.RoomFeature", b =>
                {
                    b.Property<string>("RoomID");

                    b.Property<string>("FeatureID");

                    b.HasKey("RoomID", "FeatureID");

                    b.HasIndex("FeatureID");

                    b.ToTable("RoomFeatureRelationships");
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.RoomType", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("BasePrice");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("RoomTypes");
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.UserContact", b =>
                {
                    b.Property<string>("UserContactId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("Email");

                    b.Property<string>("Message");

                    b.Property<string>("Name");

                    b.Property<bool>("Reply");

                    b.Property<string>("ReplyMessage");

                    b.Property<string>("Subject");

                    b.HasKey("UserContactId");

                    b.ToTable("UserContacts");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.Blog.MainComment", b =>
                {
                    b.HasOne("HotelManagementSystem.Entities.Blog.Post")
                        .WithMany("MainComments")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.Blog.SubComment", b =>
                {
                    b.HasOne("HotelManagementSystem.Entities.Blog.MainComment")
                        .WithMany("SubComments")
                        .HasForeignKey("MainCommentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.Booking", b =>
                {
                    b.HasOne("HotelManagementSystem.Entities.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("HotelManagementSystem.Entities.Room", "Room")
                        .WithMany("Bookings")
                        .HasForeignKey("RoomID");
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.Image", b =>
                {
                    b.HasOne("HotelManagementSystem.Entities.Room")
                        .WithMany("RoomImages")
                        .HasForeignKey("RoomID");
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.InventotyEntities.Product", b =>
                {
                    b.HasOne("HotelManagementSystem.Entities.InventotyEntities.Vendor", "Vendor")
                        .WithMany("Products")
                        .HasForeignKey("VendorId");
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.InventotyEntities.ProductPurchaseOrderTracking", b =>
                {
                    b.HasOne("HotelManagementSystem.Entities.InventotyEntities.Product", "Product")
                        .WithMany("ProductPurchaseOrderTrackers")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.InventotyEntities.PurchaseOrder", b =>
                {
                    b.HasOne("HotelManagementSystem.Entities.InventotyEntities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.InventotyEntities.SalesOrder", b =>
                {
                    b.HasOne("HotelManagementSystem.Entities.InventotyEntities.Product", "Product")
                        .WithMany("SalesOrderProducts")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.ItemImage", b =>
                {
                    b.HasOne("HotelManagementSystem.Entities.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.NotificationApplicationUser", b =>
                {
                    b.HasOne("HotelManagementSystem.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("NotificationApplicationUsers")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HotelManagementSystem.Entities.Notification", "Notification")
                        .WithMany("NotificationApplicationUsers")
                        .HasForeignKey("NotificationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.Review", b =>
                {
                    b.HasOne("HotelManagementSystem.Entities.Room", "Room")
                        .WithMany("Reviews")
                        .HasForeignKey("RoomID");
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.Room", b =>
                {
                    b.HasOne("HotelManagementSystem.Entities.RoomType", "RoomType")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HotelManagementSystem.Entities.RoomFeature", b =>
                {
                    b.HasOne("HotelManagementSystem.Entities.Feature", "Feature")
                        .WithMany("Rooms")
                        .HasForeignKey("FeatureID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HotelManagementSystem.Entities.Room", "Room")
                        .WithMany("Features")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HotelManagementSystem.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HotelManagementSystem.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HotelManagementSystem.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HotelManagementSystem.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
