using System;

namespace Serilog.LevelSwitcher
{/// <summary>
/// 
/// </summary>
    public class Options
    {
        /// <summary>
        /// Initialise default configuration, provide unique name for each logger if you have multiple loggers
        /// </summary>
        public Options(string id = "Global")
        {
            Id = id;
            RefreshInterval = TimeSpan.FromMinutes(1);
        }

        /// <summary>
        /// The unique Id for the original logger
        /// </summary>
        public string Id { get; set; }
        
        internal string Key => $"Logger:{Id}:Level";

        /// <summary>
        /// Refresh interval
        /// </summary>
        public TimeSpan RefreshInterval { get; set; }
    }
}