using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ApplicationInsightsLogging;

namespace ApplicationInsightsLoggingSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var applicationInsightsSetting = new ApplicationInsightsSettings();

            if (env.IsDevelopment())
            {
                applicationInsightsSetting.DeveloperMode = true;
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddApplicationInsights(applicationInsightsSetting);

            app.UseMvc();
        }
    }
}
