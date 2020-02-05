using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MayumbaApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MayumbaAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.


        //-------------------------------------------------------------------------------------------
        //let Startup.cs "know" about the DbContext
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)//dependency injection managed via services. A service is created for 
                                                                  //each feature we want the app to interact with
        {
            services.AddControllers();
            //add a service to manage the Estates Context
            services.AddDbContext<MayumbaContext>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("OwnersConnection")) //this is put in the appsettings.json file so we dont hard code it here
                .EnableSensitiveDataLogging() //EFCore logging info to be output is also specified in the appsettings.json file
            );
        }
        //-------------------------------------------------------------------------------------------




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
