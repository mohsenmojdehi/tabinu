using BAL.Services;
using BAL.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DAL.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DAL.Repository;
using AddBuzz.Helpers;
using AddBuzz.CustomeAuthorizeAttribute;
using System;

namespace AddBuzz
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(400);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });

            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // add custom service here to project
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<ITokenHelper, TokenHelper>();
            services.AddScoped<ICookieHelper, CookieHelper>();
            services.AddScoped<IAdvertisementPlanRepository, AdvertisementPlanRepository>();
            services.AddScoped<IGraphicDesigningPlanService, GraphicDesigningPlanService>(); 
            services.AddScoped<IGraphicDesigningPlanRepository, GraphicDesigningPlanRepository>();
            services.AddScoped<IAdvertisementPlanService, AdvertisementPlanService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //string cnstr = Configuration.GetConnectionString("AdBuzzConnections");
            services.AddDbContext<DataBaseContext>(item => item.UseSqlServer(Configuration.GetConnectionString("AdBuzzConnections")));
            //services.AddScoped<AuthorizeFilter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseSession();
            app.UseCookiePolicy();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
