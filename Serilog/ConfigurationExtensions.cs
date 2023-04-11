using Microsoft.Extensions.Configuration;
using Serilog;
using SysLog = Serilog;

namespace PayrollEngine.Serilog
{
    /// <summary>Extension for the serilog configuration</summary>
    public static class ConfigurationExtensions
    {
        /// <summary>Setup serilog </summary>
        public static void SetupSerilog(this IConfiguration configuration)
        {
            SysLog.Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
            Log.SetLogger(new PayrollLog());
        }
    }
}
