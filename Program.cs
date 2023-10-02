using Ecommerce_CyberKnight.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Ecommerce_CyberKnight {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            var _mySQLServerVersion = new MySqlServerVersion(new Version(8, 0, 33));

            builder.Services.AddDbContext<ApplicationDbContext>(
                        options => options.UseMySql(
                                            builder.Configuration.GetConnectionString("ApplicationDbContext"),
                                            _mySQLServerVersion, 
                                            opt => opt.EnableRetryOnFailure()
										)
                        );

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment()) {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}