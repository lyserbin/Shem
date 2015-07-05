using System;
using System.IO;

namespace SharpStem.Utils
{
    /// <summary>
    /// Enum to present the various LogLevel types.
    /// </summary>
    public enum LogType
    {
        NONE,
        ERROR,
        WARNING,
        INFO,
        DEBUG
    }

    /// <summary>
    /// Class used to log things to files.
    /// It is static, if you want to change the log-level,
    /// change the 'LogLevel' property.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Represent the level of logging.
        /// DEBUG will log DEBUG, INFO, WARNING and ERROR,
        /// in the same way INFO will log INFO, WARNING and ERROR,
        /// and so on this way.
        /// </summary>
        public static LogType LogLevel = LogType.INFO;

        private static string _logfile = "sharpstem.log";
        
        /// <summary>
        /// Log a message.
        /// </summary>
        /// <param name="type">The type of the log (DEBUG, INFO, WARNING, ERROR).</param>
        /// <param name="message">The message to be logged.</param>
        /// <param name="what">A <c>LogHow</c> class that specify what to log.</param>
        public static void Log(LogType type, string message, bool logtoconsole = true, bool logtofile = true)
        {
            if (LogLevel >= type)
            {
                string formatted = String.Format("{0} [{1}]: {2}", DateTime.Now, type.ToString(), message);

                if (logtoconsole) Console.WriteLine(formatted);
                if (logtofile) File.AppendAllText(_logfile, formatted + "\r\n");
            }
        }
    }
}
