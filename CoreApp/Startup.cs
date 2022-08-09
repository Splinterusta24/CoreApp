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
            services.AddRazorPages(); //Bunu gerek yok mvc için silebiliriz.
            services.AddControllersWithViews();//mvc için controller ve view kullanýmýný açar.
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

            app.UseStaticFiles();//Dýþarýya açýlan dosyalarý belirtir.wwwroot
            //http://localhost:5000/Home/Index //neden???
            app.UseRouting();//Yönlendirme Home/Index.
            app.UseMiddleware<RequestEditingMiddleware>(); // yazdýðýmýz middleware i burada tanýtýyorum.
            app.UseMiddleware<ResponseEditingMiddleware>();


            app.UseAuthorization();//Ýnternet sitesine giriþte yetkilendirme yazabiliyorsun.

            //response Yönetimi
            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{Controller}/{Action}",
                    defaults:new {Controller = "Home", Action = "Index" } //url den sonra path yazmaz bunu yapýnca.
                    );
            //mvc için byrayý siliyoruz.    endpoints.MapRazorPages(); //Responslara karþýlýk gelen kýsýmlardýr. Ýlgili razaor page i kullanýcýya sun.
                //endpoints.MapGet(
                //    "/kaan", async context =>
                //    {
                //        await context.Response.WriteAsync("Hoþgeldiniz");
                //        //context response veya requestin objesidir.
                //    }
                //    );
            });
        }
    }
}
