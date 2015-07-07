using System;
using System.IO;

namespace Shem.Utils
{
    /// <summary>
    /// Enum to present the various LogLevel types.
    /// </summary>
    public enum LogType
    {
        /// <summary>
        /// Don't log shit.
        /// </summary>
        NONE,

        /// <summary>
        /// Log errors only.
        /// </summary>
        ERROR,

        /// <summary>
        /// Warning and errors will be logged (RECCOMENDED CHOOSE! =D).
        /// </summary>
        WARNING,

        /// <summary>
        /// Notices, warnings and errors will be logged.
        /// </summary>
        INFO,

        /// <summary>
        /// Log everything loggable.
        /// </summary>
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
        /// Represent the level of logging to the console.
        /// </summary>
        public static LogType ConsoleLogLevel = LogType.INFO;

        /// <summary>
        /// Represent the level of logging to the file.
        /// </summary>
        public static LogType FileLogLevel = LogType.WARNING;

        // the file where to log to.
        private static string _logfile = "shem.log";
        
        /// <summary>
        /// Log a message.
        /// </summary>
        /// <param name="type">The type of the log (DEBUG, INFO, WARNING, ERROR).</param>
        /// <param name="message">The message to be logged.</param>
        /// <param name="logtoconsole">Should the message be logged to the console?</param>
        /// <param name="logtofile">Should the message be logged to file?</param>
        public static void Log(LogType type, string message, bool logtoconsole = true, bool logtofile = true)
        {
            if (ConsoleLogLevel >= type && logtoconsole)
                Console.WriteLine(String.Format("[{0} {1}] {2}", DateTime.Now.ToString("HH:mm:ss"), type.ToString(), message));

            if (FileLogLevel >= type && logtofile)
                File.AppendAllText(_logfile, String.Format("[{0} {1}] {2}\r\n", DateTime.Now, type.ToString(), message));

        }
    }
}
