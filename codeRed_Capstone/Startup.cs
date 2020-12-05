using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//NOV 17 add using statement for dependancy injection
using codeRed_Capstone.Models;
//Dec 5 added service for cookies
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
//Dec 5 added service for cookies
using Microsoft.AspNetCore.Identity;
//NOV17 IMPORTED FOR USESQLSERVER 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace codeRed_Capstone
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
            services.AddRazorPages();


            // cookie policy to deal with temporary browser incompatibilities
            //services.AddSameSiteCookiePolicy();
            //services.AddDefaultAllowAllCors();
            services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme, option =>
            {
                option.Cookie.Name = "codeRedCookie"; // change cookie name
                option.ExpireTimeSpan = TimeSpan.FromDays(1); // change cookie expire time span
            });

            //NOV17 inject dependancy
            services.AddDbContext<CompanyContext>();
        //    (options =>
        //options.UseMySql(Configuration.GetConnectionString("XAMPPConnection")));
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
                app.UseExceptionHandler("/Home/Error");
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Employee}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
