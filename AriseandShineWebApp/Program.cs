using AriseandShineWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AriseandShineWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register MVC controllers and views
            builder.Services.AddControllersWithViews();

            // Add Authorization (this fixes your current error)
            builder.Services.AddAuthorization();

            // (Optional) Add Authentication if you plan to use Identity or login features
            // builder.Services.AddAuthentication();

            // Add DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Apply authentication and authorization
            // app.UseAuthentication(); // Uncomment if using authentication
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
