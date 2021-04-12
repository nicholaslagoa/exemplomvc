using ExemploMVC.Models;
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

namespace ExemploMVC
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
        {//configura serviços para serem usados na aplicação toda por DI
            services.AddControllersWithViews();
            services.AddDbContext<Context>();//adiciona o context usado no startup para assim poder utilizá-lo de fato
            //vale dizer que entre () também pode ser adicionado a connectionstring aparentemente
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {//configura os middlewares a serem utilizados
            if (env.IsDevelopment())//se tiver em ambiente de desenvolvimento
            {
                app.UseDeveloperExceptionPage();
            }
            else//caso não, usar hsts
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();//se redirecionar com http, muda para https
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {//localização do route
                endpoints.MapControllerRoute(
                    name: "default",//se não tiver nada, joga pra \/
                    pattern: "{controller=Home}/{action=Index}/{id?}");//home
            });
        }
    }
}
