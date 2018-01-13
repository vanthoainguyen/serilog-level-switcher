using Serilog.Events;
using Serilog.LevelSwitcher;

namespace Serilog
{
    /// <summary>
    /// Extension methods to <see cref="ILogger"/>
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Wrap the current logger and make it's default level overridable. Store value in redis
        /// </summary>
        /// <param name="originLogger"></param>
        /// <param name="redisConnectionString"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static ILogger OverrideLevel(this ILogger originLogger, Options config, string redisConnectionString)
        {
            return OverrideLevel(originLogger, config, new RedisStore(redisConnectionString));
        }

        /// <summary>
        /// Wrap the current logger and make it's default level overridable
        /// </summary>
        /// <param name="originLogger"></param>
        /// <param name="store"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static ILogger OverrideLevel(this ILogger originLogger, Options config, IKeyValueStore store)
        {
            if (originLogger is LevelOverrideLogger)
            {
                return ((LevelOverrideLogger)originLogger).Configure(store, config);
            }

            return new LevelOverrideLogger(originLogger, GetMinimumLevel(originLogger), store, config);
        }

        private static LogEventLevel GetMinimumLevel(ILogger logger)
        {
            if (logger.IsEnabled(LogEventLevel.Verbose))
                return LogEventLevel.Verbose;
            if (logger.IsEnabled(LogEventLevel.Debug))
                return LogEventLevel.Debug;
            if (logger.IsEnabled(LogEventLevel.Information))
                return LogEventLevel.Information;
            if (logger.IsEnabled(LogEventLevel.Warning))
                return LogEventLevel.Warning;
            if (logger.IsEnabled(LogEventLevel.Error))
                return LogEventLevel.Error;
            if (logger.IsEnabled(LogEventLevel.Fatal))
                return LogEventLevel.Fatal;

            return LogEventLevel.Information;
        }
    }
}
