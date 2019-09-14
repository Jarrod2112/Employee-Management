using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace EmployeeManagement
{
    public class Startup
    {
        private IConfiguration _config;

        public int SourceCodeLineCount { get; private set; }

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Creates a pool of insaces and uses those instead of creating a new one.
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("EmployeeDBConnection")));
                
            
            // Works for MVC.Core as well
            services.AddMvc();
            
            // Use "AddScoped" for each incoming request throghh out the entire scope. Allowing it to refresh each new request.
            // Creates and instance and use SQLEmployeeRepository to handle data.
            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)

        {
            if (env.IsDevelopment())
            {
                
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                // Adds default Route
                routes.MapRoute("default","{controller=Home}/{action=Index}/{id?}");
            });
            



        }
    }
}
