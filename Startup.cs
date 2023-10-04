using Ecommerce_CyberKnight.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_CyberKnight {
	public class Startup {

		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}
		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services) {

			services.AddRazorPages();

			var _mySQLServerVersion = new MySqlServerVersion(new Version(8, 0, 33));

			 services.AddDbContext<ApplicationDbContext>(
						options => options.UseMySql(
											Configuration.GetConnectionString("ApplicationDbContext"),
											_mySQLServerVersion,
											opt => opt.EnableRetryOnFailure()
										)
						);
		}

		public void Configure(WebApplication app, IWebHostEnvironment env) {
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

