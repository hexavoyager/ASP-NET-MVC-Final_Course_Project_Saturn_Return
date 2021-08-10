using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BR = SR_BLL.Repos;
using BS = SR_BLL.Services;
using SR_DAL.Repos;
using SR_DAL.Services;
using SR_MVC.Infrastructure.Session;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Tools.Connections.Database;

namespace SR_MVC
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
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddTransient(sp =>
            {
                HttpClient httpClient = new HttpClient() { BaseAddress = new Uri("https://localhost:7001/") };
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                ISessionManager sessionManager = sp.GetService<ISessionManager>();
                if (sessionManager.Client is not null)
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessionManager.Client.Token);

                return httpClient;
            });

            services.AddScoped(sp => new Connection(SqlClientFactory.Instance, Configuration.GetConnectionString("SR_DB")));
            services.AddScoped<IClientRepo, ClientService>();
            services.AddScoped<IPlanetRepo, PlanetService>();
            services.AddScoped<IBookingRepo, BookingService>();
            services.AddScoped<BR.IClientRepo, BS.ClientService>();
            services.AddScoped<BR.IPlanetRepo, BS.PlanetService>();
            services.AddScoped<BR.IBookingRepo, BS.BookingService>();
            services.AddSingleton <ISessionManager, SessionManager>();


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
            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
