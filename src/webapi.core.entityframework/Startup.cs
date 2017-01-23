using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MySQL.Data.Entity.Extensions;
using webapi.core.entityframework.Services;
using webapi.core.entityframework.DAL;
using Microsoft.Extensions.Options;
using webapi.core.entityframework.Models;
using webapi.core.entityframework.Filters;
using Mapster;
using System.Reflection;
using webapi.core.entityframework.Services.Businesses;
using webapi.core.entityframework.Services.Categories;

namespace webapi.core.entityframework
{
    public class Startup
    {

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddJsonFile("DAL/config.json", optional: true, reloadOnChange: true);
            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(LinkRewritingFilter));
                options.Filters.Add(typeof(JsonExceptionFilter));
            });

            //The Connection String is defined in ./DAL/config.json
            var mySqlConnectionString = Configuration.GetConnectionString("DataAccessMySqlProvider");
            services.AddDbContext<DbWebApiContext>(
                options =>
                    options.UseMySQL(
                        mySqlConnectionString,
                        b => b.MigrationsAssembly("webapi.core.entityframework")
                    )
                );

            // Save the default paged collection parameters to the DI container
            // so we can easily retrieve them in a controller
            services.AddSingleton(Options.Create(new PagedCollectionParameters
            {
                Limit = 25,
                Offset = 0
            }));

            // Add POCO mapping configurations
            var typeAdapterConfig = new TypeAdapterConfig();
            typeAdapterConfig.Scan(typeof(Startup).GetTypeInfo().Assembly);
            services.AddSingleton(typeAdapterConfig);

            services.AddSingleton<UnitOfWork, UnitOfWork>();
            services.AddSingleton<BusinessServices, BusinessServices>();
            services.AddSingleton<CategoryServices, CategoryServices>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            app.UseMvc(opt =>
            {
                opt.MapRoute("default", "{controller}/{id?}/{link?}");
            });
        }
    }
}
