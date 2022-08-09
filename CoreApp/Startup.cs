using CoreApp.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp
{
    //Ana middleware
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
            services.AddRazorPages(); //Bunu gerek yok mvc i�in silebiliriz.
            services.AddControllersWithViews();//mvc i�in controller ve view kullan�m�n� a�ar.
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
            }

            app.UseStaticFiles();//D��ar�ya a��lan dosyalar� belirtir.wwwroot
            //http://localhost:5000/Home/Index //neden???
            app.UseRouting();//Y�nlendirme Home/Index.
            app.UseMiddleware<RequestEditingMiddleware>(); // yazd���m�z middleware i burada tan�t�yorum.
            app.UseMiddleware<ResponseEditingMiddleware>();


            app.UseAuthorization();//�nternet sitesine giri�te yetkilendirme yazabiliyorsun.

            //response Y�netimi
            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{Controller}/{Action}",
                    defaults:new {Controller = "Home", Action = "Index" } //url den sonra path yazmaz bunu yap�nca.
                    );
            //mvc i�in byray� siliyoruz.    endpoints.MapRazorPages(); //Responslara kar��l�k gelen k�s�mlard�r. �lgili razaor page i kullan�c�ya sun.
                //endpoints.MapGet(
                //    "/kaan", async context =>
                //    {
                //        await context.Response.WriteAsync("Ho�geldiniz");
                //        //context response veya requestin objesidir.
                //    }
                //    );
            });
        }
    }
}
