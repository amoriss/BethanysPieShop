using BethanysPieShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IPieRepository, PieRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            //services.AddTransient();  --> gives a new instance every time you ask for one
            //services.AddSingleton(); ---> a single instance for the entire application and reuse that single instance
            //services.AddScoped();  ---> per request, an instance will be created, and that instance remains active throughout the entire request
            services.AddControllersWithViews();            
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(); //Responsible for serving static files and that will default to serving the files in the wwwroot folder 
                                   //Bootstrap has a dependency on jQuery 
            app.UseRouting();


            // Route defaults:
            // When a request comes in that does not specify a value for the controller nor the action
            // part, MVC will use these defaults. This will allow us to send a request to the root 
            // of the site and automatically the index action of the home controller will be executed
            // The id gives you the option to pass in a value for a selected pie. The question mark allows
            // id to be optional.
            app.UseEndpoints(endpoints =>
            {             
                //Configuring the Routing System
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                    // adding a constraint would look like this: {id:int?}
                    // the int part is the constraint. the last segment will not match if it is not an integer value
                    // this allows us to check the actual content of the segment

            });
        }
    }
}
