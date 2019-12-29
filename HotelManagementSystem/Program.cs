﻿
using HotelManagementSystem.Entities;
using HotelManagementSystem.Services;
using HotelManagementSystem.Services.MessagingService;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace HotelManagementSystem
{
    public class Program
    {
  
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>().
            UseDefaultServiceProvider(options =>options.ValidateScopes = false);
    }
}
