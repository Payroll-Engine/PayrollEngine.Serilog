using System;
using SysLog = Serilog;

namespace PayrollEngine.Serilog
{
    /// <summary>Serilog logger</summary>
    public class PayrollLog : ILogger
    {
        private static SysLog.ILogger Logger => SysLog.Log.Logger;

        #region Logger

        /// <summary>Determine if events at the specified level will be passed through to the log sinks</summary>
        /// <param name="level">Level to check</param>
        /// <returns>True if the level is enabled; otherwise, false</returns>
        public bool IsEnabled(LogLevel level) =>
            Logger.IsEnabled((SysLog.Events.LogEventLevel)level);

        #endregion

        #region Write

        /// <summary>Write a log event with the specified level</summary>
        /// <param name="level">The level of the event</param>
        /// <param name="messageTemplate">Message template describing the event</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template</param>
        public void Write(LogLevel level, string messageTemplate, params object[] propertyValues) =>
            Logger.Write((SysLog.Events.LogEventLevel)level, messageTemplate, propertyValues);

        /// <summary>Write a log event with the specified level and associated exception</summary>
        /// <param name="level">The level of the event</param>
        /// <param name="exception">Exception related to the event</param>
        /// <param name="messageTemplate">Message template describing the event</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template</param>
        public void Write(LogLevel level, Exception exception, string messageTemplate, params object[] propertyValues) =>
            Logger.Write((SysLog.Events.LogEventLevel)level, exception, messageTemplate, propertyValues);

        #endregion

        #region Trace

        /// <summary>Write a log event with the <see cref="LogLevel.Verbose"/> level</summary>
        /// <param name="messageTemplate">Message template describing the event</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template</param>
        /// <example>
        /// Log.Verbose("Staring into space, wondering if we're alone.");
        /// </example>
        public void Trace(string messageTemplate, params object[] propertyValues) =>
            Logger.Verbose(messageTemplate, propertyValues);

        /// <summary>Write a log event with the <see cref="LogLevel.Verbose"/> level and associated exception</summary>
        /// <param name="exception">Exception related to the event</param>
        /// <param name="messageTemplate">Message template describing the event</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template</param>
        /// <example>
        /// Log.Verbose(ex, "Staring into space, wondering where this comet came from.");
        /// </example>
        public void Trace(Exception exception, string messageTemplate, params object[] propertyValues) =>
            Logger.Verbose(exception, messageTemplate, propertyValues);

        #endregion

        #region Debug

        /// <summary>Write a log event with the <see cref="LogLevel.Debug"/> level</summary>
        /// <param name="messageTemplate">Message template describing the event</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template</param>
        /// <example>
        /// Log.Debug("Starting up at {StartedAt}.", DateTime.Now);
        /// </example>
        public void Debug(string messageTemplate, params object[] propertyValues) =>
            Logger.Debug(messageTemplate, propertyValues);

        /// <summary>Write a log event with the <see cref="LogLevel.Debug"/> level and associated exception</summary>
        /// <param name="exception">Exception related to the event</param>
        /// <param name="messageTemplate">Message template describing the event</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template</param>
        /// <example>
        /// Log.Debug(ex, "Swallowing a mundane exception");
        /// </example>
        public void Debug(Exception exception, string messageTemplate, params object[] propertyValues) =>
            Logger.Debug(exception, messageTemplate, propertyValues);

        #endregion

        #region Information

        /// <summary>Write a log event with the <see cref="LogLevel.Information"/> level</summary>
        /// <param name="messageTemplate">Message template describing the event</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template</param>
        /// <example>
        /// Log.Information("Processed {RecordCount} records in {TimeMS}.", records.Length, sw.ElapsedMilliseconds);
        /// </example>
        public void Information(string messageTemplate, params object[] propertyValues) =>
            Logger.Information(messageTemplate, propertyValues);

        /// <summary>Write a log event with the <see cref="LogLevel.Information"/> level and associated exception</summary>
        /// <param name="exception">Exception related to the event</param>
        /// <param name="messageTemplate">Message template describing the event</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template</param>
        /// <example>
        /// Log.Information(ex, "Processed {RecordCount} records in {TimeMS}.", records.Length, sw.ElapsedMilliseconds);
        /// </example>
        public void Information(Exception exception, string messageTemplate, params object[] propertyValues) =>
            Logger.Information(exception, messageTemplate, propertyValues);

        #endregion

        #region Warning

        /// <summary>Write a log event with the <see cref="LogLevel.Warning"/> level</summary>
        /// <param name="messageTemplate">Message template describing the event</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template</param>
        /// <example>
        /// Log.Warning("Skipped {SkipCount} records.", skippedRecords.Length);
        /// </example>
        public void Warning(string messageTemplate, params object[] propertyValues) =>
            Logger.Warning(messageTemplate, propertyValues);

        /// <summary>Write a log event with the <see cref="LogLevel.Warning"/> level and associated exception</summary>
        /// <param name="exception">Exception related to the event</param>
        /// <param name="messageTemplate">Message template describing the event</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template</param>
        /// <example>
        /// Log.Warning(ex, "Skipped {SkipCount} records.", skippedRecords.Length);
        /// </example>
        public void Warning(Exception exception, string messageTemplate, params object[] propertyValues) =>
            Logger.Warning(exception, messageTemplate, propertyValues);

        #endregion

        #region Error

        /// <summary>Write a log event with the <see cref="LogLevel.Error"/> level</summary>
        /// <param name="messageTemplate">Message template describing the event</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template</param>
        /// <example>
        /// Log.Error("Failed {ErrorCount} records.", brokenRecords.Length);
        /// </example>
        public void Error(string messageTemplate, params object[] propertyValues) =>
            Logger.Error(messageTemplate, propertyValues);

        /// <summary>Write a log event with the <see cref="LogLevel.Error"/> level and associated exception</summary>
        /// <param name="exception">Exception related to the event</param>
        /// <param name="messageTemplate">Message template describing the event</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template</param>
        /// <example>
        /// Log.Error(ex, "Failed {ErrorCount} records.", brokenRecords.Length);
        /// </example>
        public void Error(Exception exception, string messageTemplate, params object[] propertyValues) =>
            Logger.Error(exception, messageTemplate, propertyValues);

        #endregion

        #region Critical

        /// <summary>Write a log event with the <see cref="LogLevel.Fatal"/> level</summary>
        /// <param name="messageTemplate">Message template describing the event</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template</param>
        /// <example>
        /// Log.Fatal("Process terminating.");
        /// </example>
        public void Critical(string messageTemplate, params object[] propertyValues) =>
            Logger.Fatal(messageTemplate, propertyValues);

        /// <summary>Write a log event with the <see cref="LogLevel.Fatal"/> level and associated exception</summary>
        /// <param name="exception">Exception related to the event</param>
        /// <param name="messageTemplate">Message template describing the event</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template</param>
        /// <example>
        /// Log.Fatal(ex, "Process terminating.");
        /// </example>
        public void Critical(Exception exception, string messageTemplate, params object[] propertyValues) =>
            Logger.Fatal(exception, messageTemplate, propertyValues);

        #endregion
    }
}
