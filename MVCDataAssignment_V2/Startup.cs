using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCDataAssignment_V2.Models;
using MVCDataAssignment_V2.Data;
using MVCDataAssignment_V2.Models.Repo;
using MVCDataAssignment_V2.Models.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MVCDataAssignment_V2
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<PeopleDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllersWithViews();

            services.AddScoped<IPeopleRepo, DbPeopleRepo>();
            //services.AddScoped<IPeopleRepo, InMemoryPeopleRepo>();
            services.AddScoped<IPeopleService, PeopleService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICitysRepo, DbCitysRepo>();
            services.AddScoped<ICountryRepo, DbCountryRepo>();
            services.AddScoped<ILanguageRepo, DbLanguageRepo>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IPersonLanguageRepo, DbPersonLanguageRepo>();
            services.AddScoped<IPersonLanguageService, PersonLanguageService>();
            //services.AddTransient<DbContext, PeopleDbContext>();

            services.AddDistributedMemoryCache();

            

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddMvc();

            // //Will be used later maybe
            services.AddMvc().AddRazorRuntimeCompilation();
            services.AddRazorPages();


            services.AddIdentity<AccountPerson, IdentityRole>()
                .AddEntityFrameworkStores<PeopleDbContext>()
                .AddDefaultTokenProviders();



            /*services.Configure<IdentityOptions>(options =>
            {
                // Default Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
            });*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();

               endpoints.MapControllerRoute(
                        name: "lastRoute",
                        pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
            
        }
    }
}
