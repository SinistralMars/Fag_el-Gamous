using Fag_el_Gamous.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MySql.EntityFrameworkCore;
using Fag_el_Gamous.Models;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

namespace Fag_el_Gamous
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
            var configBuilder = new ConfigurationBuilder()
            .AddUserSecrets<Startup>();

            IConfiguration config = configBuilder.Build();

            string mainConnection = config["MainConnection"];
            string burialConnection = config["BurialConnection"];


            services.AddScoped<IFagelGamousRepository, EFFagelGamousRepository>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential 
                // cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                // requires using Microsoft.AspNetCore.Http;
                options.MinimumSameSitePolicy = SameSiteMode.None;
               //  var options = new CookiePolicyOptions();
                options.ConsentCookie.SecurePolicy = CookieSecurePolicy.Always;
            });

            // Password requirements
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 12;
            });

            // HSTS requirement
            services.AddHsts(options =>
            {
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(365);
            });

            //Database for user authentication
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySQL(mainConnection);
            });

            //Database for burial info
            services.AddDbContext<BurialContext>(options =>
            {
                options.UseNpgsql(burialConnection);
            });

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllersWithViews();
            services.AddRazorPages();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

           

            app.Use(async (context, next) =>
            {
                string scriptHash = "'sha256-m1igTNlg9PL5o60ru2HIIK6OPQet2z9UgiEAhCyg/RU='";
                context.Response.Headers.Add("Content-Security-Policy", $"default-src 'self'; script-src 'self' http://www.w3.org {scriptHash} 'nonce-J0joD1o'; font-src 'self'; img-src 'self' http://www.w3.org data:; frame-src 'self'; style-src 'self' 'unsafe-hashes' 'sha256-aqNNdDLnnrDOnTNdkJpYlAxKVJtLt9CtFLklmInuUAE=' 'sha256-zNKhlN0wtj8TVJ20RuIjNArjRLBf4ddugEFnDzX1Aos=' 'sha256-9KmcHQCuKbiZDnrghoC9HOmY49nvpfQTG0riBGcLFt0=' 'sha256-j/K1G9wQNbYz7sx/HppMAseOdTHh3MvUzs2vf+DupMQ='");
                await next();
            });

            app.UseEndpoints(endpoints =>
            {
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "controller-action",
                        pattern: "{controller=Home}/{action=Index}/{id?}");    
                });
                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();
            });
        }
    }
}
