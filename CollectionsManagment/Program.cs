using CollectionsManagment.Abstractions.GenRepositoryAbstractions;
using CollectionsManagment.Buisness.Services;
using CollectionsManagment.Core.Abstractrions;
using CollectionsManagment.DataBase;
using CollectionsManagment.DataBase.Entities;
using CollectionsManagment.GenericRepository.GenRepository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using System.Numerics;

namespace CollectionsManagment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
             
            //serilog
            builder.Host.UseSerilog((ctx, lc) =>
            lc.WriteTo.File(@"E:\Itransition\CollectionsManagment\data.log",
            LogEventLevel.Information).WriteTo.Console(LogEventLevel.Verbose)
            );

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options =>
               {
                   options.ExpireTimeSpan = TimeSpan.FromHours(1);
                   options.AccessDeniedPath = new PathString("/Account/Authentication");
                   options.LoginPath = new PathString("/Account/Authentication");
               });
             

            var connectionString = builder.Configuration.GetConnectionString("Default");
            //dependency Injection DataBase
            builder.Services.AddDbContext<CollectionsManagmentContext>(optionsBuilder => optionsBuilder.UseSqlServer(connectionString));

            //dependency Injection AutoMapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            
            //Dependency Injection Services 
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IUserService, UserService>();


            //Dependency Injection GenericRepository
            builder.Services.AddScoped<IRepository<User>, Repository<User>>();
            builder.Services.AddScoped<IRepository<Account>, Repository<Account>>();
            builder.Services.AddScoped<IRepository<Role>, Repository<Role>>();
            builder.Services.AddScoped<IRepository<Collection>, Repository<Collection>>();
            builder.Services.AddScoped<IRepository<Comment>, Repository<Comment>>();
            builder.Services.AddScoped<IRepository<Item>, Repository<Item>>();
            builder.Services.AddScoped<IRepository<Like>, Repository<Like>>(); 

            //Dependency Injection UnitOfWork
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting(); 

            app.UseAuthentication(); // Set HttpContex.User
            app.UseAuthorization();  // Check Users Succes 

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}