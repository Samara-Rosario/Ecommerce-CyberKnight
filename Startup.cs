using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Ecommerce_CyberKnight {
	public class Startup {

		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}
		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services) {
			services.Configure<CookiePolicyOptions>(options => {
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.Lax;
			});

		    services.AddIdentity<AppUser, IdentityRole>(options => {
			   options.User.RequireUniqueEmail = true;
			   options.Password.RequireNonAlphanumeric = false;
			   options.Password.RequireLowercase = false;
			   options.Password.RequireUppercase = false;
			   options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
			   options.Lockout.MaxFailedAccessAttempts = 3;
			   options.SignIn.RequireConfirmedAccount = false;
			   options.SignIn.RequireConfirmedEmail = false;
			   options.SignIn.RequireConfirmedPhoneNumber = false;
		    }).AddEntityFrameworkStores<ApplicationDbContext>();


			services.ConfigureApplicationCookie(options =>
			{
				options.Cookie.HttpOnly = true;
				options.ExpireTimeSpan = TimeSpan.FromMinutes(3);
				options.LoginPath = "/Login";
				options.AccessDeniedPath = "/Login";
				options.SlidingExpiration = true;
			});

			services.AddAuthorization(options => {
				//Add uma política de acesso com o nome isAdmin
				options.AddPolicy("isAdmin", policy =>
				policy.RequireRole("admin"));
			});

			//Adiciona o uso do Razor Pages
			services.AddRazorPages(options => {
				options.Conventions.AuthorizePage("/ProdutoCRUD", "isAdmin");
				options.Conventions.AuthorizePage("/ClienteCRUD", "isAdmin");
			}).AddCookieTempDataProvider(opt => opt.Cookie.IsEssential = true);


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

            app.UseCookiePolicy();
			
            app.UseRouting();

			app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints => {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });

            var defaultCulture = new CultureInfo("pt-BR");
			var localizationOptions = new RequestLocalizationOptions {
				DefaultRequestCulture = new RequestCulture(defaultCulture),
				SupportedCultures = new List<CultureInfo> { defaultCulture },
				SupportedUICultures = new List<CultureInfo> { defaultCulture }
			};

			app.UseRequestLocalization(localizationOptions);

			app.MapRazorPages();

			app.Run();
		}
	}
}