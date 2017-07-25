using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using LabCubes.Services.Services;
using LabCubes.Services.Interface;

namespace LabCubes.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(env.ContentRootPath)
                            .AddJsonFile("appsettings.json")
                            .AddEnvironmentVariables();

           Configuration= builder.Build();
        }
        public IConfiguration Configuration { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton(Configuration);
            services.Configure<Utilities.AppSettings>(x => Configuration.GetSection("AppSettings").Bind(x));
            services.AddSingleton<IPersonService, PersonService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            ILoggerFactory loggerFactory
            ,IOptions<Utilities.AppSettings> appSettings)
        {
            loggerFactory.AddConsole();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //Development Connection String 
                Utilities.Constants.ConnectionString = appSettings.Value.DevConnectionString;

            }
            if (env.IsStaging())//For Staging Environment
            {
                //Development Connection String 
                //Utilities.Common.ConnectionString = appSettings.Value.DevConnectionString;
            }
            if (env.IsProduction())
            {
                //Development Connection String 
                Utilities.Constants.ConnectionString = appSettings.Value.ProdConnectionString;
            }
            app.UseMvc();
            
        }
    }
}
