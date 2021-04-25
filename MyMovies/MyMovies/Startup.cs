using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyMovies.Common;
using MyMovies.Common.Services;
using MyMovies.Custom;
using MyMovies.Repository;
using MyMovies.Repository.Interfaces;
using MyMovies.Service;
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
            services.AddDbContext<MyMoviesDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("MyMoviesDb")));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
                options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromDays(int.Parse(Configuration["CookieExpirationPeriod"]));
                    options.LoginPath = "/Auth/SignIn";
                    options.AccessDeniedPath = "/Auth/AccessDenied";
                    //options.SlidingExpiration = false; -- da se iskluci i pokraj aktivnost

                }
                );
            services.AddAuthorization(options =>
            {
                options.AddPolicy("IsAdmin", policy =>
                {
                    policy.RequireClaim("IsAdmin", "True");
                });
            });

            services.Configure<SideBarConfig>(Configuration.GetSection("SideBarConfig"));
            services.AddControllersWithViews();
            services.AddTransient<IMoviesService, MoviesService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<ICommentsService, CommentsService>();
            services.AddTransient<ISideBarService, SideBarService>();
            services.AddTransient<ILogService, LogService>();
            services.AddTransient<IMovieGenresService, MovieGenresService>();
            services.AddTransient<IMovieLikesService, MovieLikesService>();

            //services.AddTransient<IMoviesRepository, MoviesMemoryRepository>();
            //services.AddTransient<IMoviesRepository, MoviesFileRepository>();
            //services.AddTransient<IMoviesRepository, MoviesSqlRepository>();
            services.AddTransient<IMoviesRepository, MoviesRepository>();
            services.AddTransient<IUserRepository, UsersRepository>();
            services.AddTransient<ICommentsRepository, CommentsRepository>();
            services.AddTransient<IMovieGenresRepository, MovieGenresRepository>();
            services.AddTransient<IMovieLikesRepository, MovieLikesRepository>();
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
            
            app.UseMiddleware<ExceptionLoggingMiddleware>();
            app.UseMiddleware<RequestResponseLogMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Movies}/{action=Overview}/{id?}");
            });
        }
    }

}
