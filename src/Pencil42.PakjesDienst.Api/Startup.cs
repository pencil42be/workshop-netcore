using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NJsonSchema;
using NSwag.AspNetCore;
using NSwag.SwaggerGeneration.WebApi;
using Pencil42.PakjesDienst.Db;

namespace Pencil42.PakjesDienst.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var b = new ConfigurationBuilder();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.Configure<PakjesQueueSettings>(Configuration.GetSection(PakjesQueueSettings.SectionName));
            services.AddSingleton(typeof(QueueSender));

            var connection =  Configuration.GetConnectionString(Constants.ConnectionStrings.Pakjes);
            services.AddDbContext<PakjesContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddDebug();
            loggerFactory.AddConsole();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwaggerUi(typeof(Startup).Assembly, settings =>
                {
                    settings.GeneratorSettings.DefaultPropertyNameHandling = PropertyNameHandling.CamelCase;
                });

        }
    }
}
