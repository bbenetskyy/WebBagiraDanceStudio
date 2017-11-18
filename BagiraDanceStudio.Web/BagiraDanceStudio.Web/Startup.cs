using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using BagiraDanceStudio.Db.Models;
using System.IO;
using Microsoft.EntityFrameworkCore.Design;
using BagiraDanceStudio.Db.Interfaces;
using BagiraDanceStudio.Db.Repository;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BagiraDanceStudio.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            Configuration = configuration;
            _serviceProvider = serviceProvider;
        }

        public IConfiguration Configuration { get; }
        private IServiceProvider _serviceProvider;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            //services.AddDbContext<DataBaseContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("ConnectionLocal")));
            
            
            services.AddDbContext<DataBaseContext>();
            services.AddMvc();
            services.AddScoped<IAbstractRepository, AbstractRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IAbstractRepository databaseRepository)
        {
            List<User> t = databaseRepository.UsersRepository.IncludeEntity<PersonData>().FindAll() as List<User>;
            foreach(User us in t)
            {
                PersonData r = us.PersonData;
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseStaticFiles();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataBaseContext>
        //{
        //    public DataBaseContext CreateDbContext(string[] args)
        //    {
        //        IConfigurationRoot configuration = new ConfigurationBuilder()
        //            .SetBasePath(Directory.GetCurrentDirectory())
        //            .AddJsonFile("appsettings.json")
        //            .Build();
        //        var builder = new DbContextOptionsBuilder<DataBaseContext>();
        //        var connectionString = configuration.GetConnectionString("ConnectionLocal");
        //        builder.UseSqlServer(connectionString);
        //        return new DataBaseContext(builder.Options);
        //    }
        //}
    }
}
