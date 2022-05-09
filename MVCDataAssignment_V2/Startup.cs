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
//using MVCDataAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace MVCDataAssignment_V2
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
            services.AddControllersWithViews();
            //services.AddScoped<IPeopleRepo, InMemoryPeopleRepo>();
            services.AddScoped<IPeopleRepo, InMemoryPeopleRepo>();
            services.AddScoped<IPeopleService, PeopleService>();

            

            services.AddDistributedMemoryCache();

            //services.AddDbContext<LibraryDbContext>(options =>
            //options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

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
