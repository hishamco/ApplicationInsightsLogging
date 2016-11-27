using ApplicationInsightsLogging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ApplicationInsightsLoggingSample
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ApplicationInsightsSettings>(options => Configuration.GetSection("ApplicationInsights").Bind(options));
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IOptions<ApplicationInsightsSettings> applicationInsightsSettings)
        {
            if (env.IsDevelopment())
            {
                 app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddApplicationInsights(applicationInsightsSettings.Value);

            app.UseMvc();
        }
    }
}
