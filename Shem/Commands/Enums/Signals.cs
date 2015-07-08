namespace Shem.Commands
{
    /// <summary>
    /// The list of signals you can send to TOR.
    /// </summary>
    public enum Signals
    {

        /// <summary>
        /// Reload config items. (like HUP)
        /// </summary>
        RELOAD,
        
        /// <summary>
        /// Controlled shutdown: if server is an OP, exit immediately. If it's an OR, close listeners and exit after ShutdownWaitLength seconds. (like INT)
        /// </summary>
        SHUTDOWN,
        
        /// <summary>
        /// Dump stats: log information about open connections and circuits. (like USR1)
        /// </summary>
        DUMP,
        
        /// <summary>
        /// Debug: switch all open logs to loglevel debug. (like USR2)
        /// </summary>
        DEBUG,
        
        /// <summary>
        /// Immediate shutdown: clean up and exit now. (like TERM)
        /// </summary>
        HALT,
        
        /// <summary>
        /// Reload config items. (like RELOAD)
        /// </summary>
        HUP,

        /// <summary>
        /// Controlled shutdown: if server is an OP, exit immediately. If it's an OR, close listeners and exit after ShutdownWaitLength seconds. (like SHUTDOWN)
        /// </summary>
        INT,

        /// <summary>
        /// Dump stats: log information about open connections and circuits. (like DUMP)
        /// </summary>
        USR1,

        /// <summary>
        /// Debug: switch all open logs to loglevel debug. (like DEBUG)
        /// </summary>
        USR2,

        /// <summary>
        /// Immediate shutdown: clean up and exit now. (like HALT)
        /// </summary>
        TERM,
        
        /// <summary>
        /// Switch to clean circuits, so new application requests don't share any circuits with old ones.
        /// Also clears the client-side DNS cache.  (Tor MAY rate-limit its response to this signal.)
        /// </summary>
        NEWNYM,
        
        /// <summary>
        /// Forget the client-side cached IPs for all hostnames.
        /// </summary>
        CLEARDNSCACHE,
        
        /// <summary>
        /// Make Tor dump an unscheduled Heartbeat message to log.
        /// </summary>
        HEARTBEAT
    }
}
