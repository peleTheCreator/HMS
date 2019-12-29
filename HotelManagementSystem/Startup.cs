 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HotelManagementSystem.Entities;
using HotelManagementSystem.Services;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using HotelManagementSystem.Data;
using HotelManagementSystem.Services.Inventory;
using HotelManagementSystem.Services.api;
using HotelManagementSystem.Services.MessagingService;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;
using AutoMapper;
using HotelManagementSystem.Infastructure;
using HotelManagementSystem.Services.BlogServices;

namespace HotelManagementSystem
{
    public class Startup
    {
        private readonly IServiceProvider serviceProvider;

        public Startup(IConfiguration configuration, IServiceProvider  serviceProvider)
        {
            Configuration = configuration;
            this.serviceProvider = serviceProvider;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
        

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            }); 

            services.AddDbContextPool<AppDbContext>(
            options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
            })
             .AddEntityFrameworkStores<AppDbContext>()
             .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = new PathString("/Adminstration/AccessDenied");
            });

            services.Configure<IdentityOptions>(options => {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 3;
                options.Password.RequireNonAlphanumeric = false;
            });

            services.AddMvc(config => {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            }).AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            }).AddXmlSerializerFormatters().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = "889865350060-8pltp271mtpcne5hm47rc6nkdu42t769.apps.googleusercontent.com";
                options.ClientSecret = "mLii62gWsr-X-bPgFZXvoVwn";
            });

            services.AddScoped(typeof(IGenericHotelService<>), typeof(GenericHotelService<>));
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IRoomServices, RoomServices>();

            //render to string
            services.AddScoped<IViewRenderService, ViewRenderService>();

            //tempdata configuration
            services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
            services.AddSession();

            // Adds a default in-memory implementation of IDistributedCache.
            services.AddDistributedMemoryCache();
            //services.AddTransient<IMessageService, MessageService>();
            // required to configure the email sender
            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);

            //notification
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddSignalR();

            //blog
            services.AddTransient<IBlogResprository, BlogResprository>();
            services.AddTransient<IFileManager, FileManager>();

            //authorization with claims
            services.AddAuthorization(options =>
            {
                options.AddPolicy("DeleteBookingPolicy",
                    policy => policy.RequireClaim("Delete Booking"));
                options.AddPolicy("CeateBookingPolicy",
                    policy => policy.RequireClaim("Create Booking"));
                options.AddPolicy("EditBookingPolicy",
                policy => policy.RequireClaim("Edit Booking"));

                options.AddPolicy("DeleteProductPolicy",
                    policy => policy.RequireClaim("Delete Product"));
                options.AddPolicy("EditProductPolicy",
                   policy => policy.RequireClaim("Edit Product"));
                options.AddPolicy("CreateProductPolicy",
                   policy => policy.RequireClaim("Create Product"));
                 

                options.AddPolicy("DeletePurchasePolicy",
                   policy => policy.RequireClaim("Delete PurchaseOrder"));
                options.AddPolicy("CreatePurchasePolicy",
                   policy => policy.RequireClaim("Create PurchaseOrder"));
                options.AddPolicy("EditPurchasePolicy",
                 policy => policy.RequireClaim("Edit PurchaseOrder"));

                options.AddPolicy("DeleteVendorPolicy",
                    policy => policy.RequireClaim("Delete Vendor"));
            });
            //automapper
            services.AddAutoMapper(typeof(Startup));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AppDbContext context,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole>roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseStaticFiles();

            
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSignalR(route =>
            {
                route.MapHub<SignalServer>("/signalServer");
            });
          //  ApplicationDbInitializer.SeedRoles(roleManager).GetAwaiter().GetResult();
         //  ApplicationDbInitializer.SeedAppUser(userManager, roleManager, serviceProvider, Configuration);
            //tempdata middleware
            app.UseSession();
        }
    }
}
