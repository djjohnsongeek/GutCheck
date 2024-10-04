using GutCheck.Core.Interfaces;
using GutCheck.Infrastructure.Data;
using GutCheck.Infrastructure.Repositories;
using GutCheck.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace GutCheck.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpContextAccessor();
            
            // Database context
            builder.Services.AddScoped<DapperContext>();

            // Business Logic Services
            builder.Services.AddScoped<IAuthService, AuthService>();

            // Data Access Repositories
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(
                authenticationScheme: CookieAuthenticationDefaults.AuthenticationScheme,
                configureOptions: o => {
                    o.LoginPath = "/auth/Login";
                    o.AccessDeniedPath = "/auth/AccessDenied";
                    o.Cookie.SameSite = SameSiteMode.Strict;
                    }
                );
            // we can add handlers to  cookie events here such OnValidatePrinciple


            // Configure the HTTP request pipeline.
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
