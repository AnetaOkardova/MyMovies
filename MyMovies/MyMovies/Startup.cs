using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyMovies.Repository;
using MyMovies.Repository.Interfaces;
using MyMovies.Services;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies
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
            services.AddDbContext<MyMoviesDbContext>(x => x.UseSqlServer("Server=(localDb)\\MSSQLLocalDB;Database= MyMovies; Trusted_Connection=True;"));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
                options =>
                {
                    //options.ExpireTimeSpan = TimeSpan.FromSeconds(5);
                    options.LoginPath = "/Auth/SignIn";
                    //options.SlidingExpiration = false; 

                }
                );
            
            services.AddControllersWithViews();
            services.AddTransient<IMoviesService, MoviesService>();
            //services.AddTransient<IMoviesRepository, MoviesMemoryRepository>();
            //services.AddTransient<IMoviesRepository, MoviesFileRepository>();
            //services.AddTransient<IMoviesRepository, MoviesSqlRepository>();
            services.AddTransient<IMoviesRepository, MoviesRepository>();
            services.AddTransient<IUserRepository, UsersRepository>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUsersService, UsersService>();

            
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
                    pattern: "{controller=Movies}/{action=Overview}/{id?}");
            });
        }
    }

}
