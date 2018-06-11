using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gm18119.Data;
using gm18119.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace gm18119
{
    public class Startup
    {

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<WineDbContext>(
                options => options.UseSqlite("Data Source=gm18119.db"));
            
            services.AddScoped<IWineData, SqlWineData>();
            services.AddScoped<IOrderData, SqlWineData>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

    /* Middlewares are usually written to look at an incoming request, or look at outgoing responses
    or trying to handle requests in some manner.
    app.Use takes a function that takes a request delegate and returns a request delegate
    request delegate takes an HTTPContext and returns a 'task' which usually is an async method */
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                // www.example.com/Controller/Action/OptionalId
                // default is www.example.com/Inventory/index

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Inventory}/{action=Index}/{id?}");
            });
        }
    }
}
