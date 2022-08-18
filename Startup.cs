using Blog_Sitesi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_Sitesi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddLocalization
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddDefaultTokenProviders()
                .AddDefaultUI()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddRazorPages();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDatabaseDeveloperPageExceptionFilter();

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();

            services.AddScoped<IDbInitializer, DbInitializer>();



            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddDefaultTokenProviders()
            //    .AddDefaultUI()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            //Language Supporting Configuration


            //services.AddLocalization(options => { options.ResourcesPath = "Resources"; });
            //services.AddMvc()
            //    .AddViewLocalization();


            //services.Configure<RequestLocalizationOptions>(
            //    options =>
            //    {
            //        var supportedCultures = new List<CultureInfo>
            //        {
            //            new CultureInfo("en-US"),
            //            new CultureInfo("tr-TR"),
            //        };

            //        options.DefaultRequestCulture = new RequestCulture(culture: "tr-TR");
            //        options.SupportedCultures = supportedCultures;
            //        options.SupportedUICultures = supportedCultures;

            //        options.RequestCultureProviders = new List<IRequestCultureProvider>
            //            {
            //                new QueryStringRequestCultureProvider(),
            //                new CookieRequestCultureProvider(),
            //                new AcceptLanguageHeaderRequestCultureProvider(),
            //            };
            //    });

            //services.AddControllersWithViews();
            //services.AddRazorPages();

            //services.AddScoped<IDbInitializer, DbInitializer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDbInitializer dbInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            var supportedCultures = new[]
            {
                new CultureInfo("tr-TR"),
                new CultureInfo("en-Us")

            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-Us"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            dbInitializer.Initialize();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
