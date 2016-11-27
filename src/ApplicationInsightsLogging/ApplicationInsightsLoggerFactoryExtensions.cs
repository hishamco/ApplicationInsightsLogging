using Microsoft.Extensions.Logging;
using System;

namespace ApplicationInsightsLogging
{
    public static class ApplicationInsightsLoggerFactoryExtensions
    {
        public static ILoggerFactory AddApplicationInsights(this ILoggerFactory factory)
        {
            return AddApplicationInsights(factory, new ApplicationInsightsSettings());
        }

        public static ILoggerFactory AddApplicationInsights(
            this ILoggerFactory factory,
            Func<string, LogLevel, bool> filter)
        {
            factory.AddProvider(new ApplicationInsightsLoggerProvider(filter));
            return factory;
        }

        public static ILoggerFactory AddApplicationInsights(
            this ILoggerFactory factory,
            ApplicationInsightsSettings settings)
        {
            factory.AddProvider(new ApplicationInsightsLoggerProvider(settings));

            return factory;
        }
    }
}
