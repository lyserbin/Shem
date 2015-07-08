
namespace Shem.Commands.Enums
{
    public enum RELAY_END
    {
        /// <summary>
        /// Catch-all for unlisted reasons
        /// </summary>
        REASON_MISC = 1,

        /// <summary>
        /// Couldn't look up hostname
        /// </summary>
        REASON_RESOLVEFAILED = 2,

        /// <summary>
        /// Remote host refused connection
        /// </summary>
        REASON_CONNECTREFUSED = 3,

        /// <summary>
        /// OR refuses to connect to host or port
        /// </summary>
        REASON_EXITPOLICY = 4,

        /// <summary>
        /// Circuit is being destroyed
        /// </summary>
        REASON_DESTROY = 5,

        /// <summary>
        /// Anonymized TCP connection was closed
        /// </summary>
        REASON_DONE = 6,

        /// <summary>
        /// Connection timed out, or OR timed out while connecting
        /// </summary>
        REASON_TIMEOUT = 7,

        /// <summary>
        /// Routing error while attempting to contact destination
        /// </summary>
        REASON_NOROUTE = 8,

        /// <summary>
        /// OR is temporarily hibernating
        /// </summary>
        REASON_HIBERNATING = 9,

        /// <summary>
        /// Internal error at the OR
        /// </summary>
        REASON_INTERNAL = 10,

        /// <summary>
        /// OR has no resources to fulfill request
        /// </summary>
        REASON_RESOURCELIMIT = 11,

        /// <summary>
        /// Connection was unexpectedly reset
        /// </summary>
        REASON_CONNRESET = 12,

        /// <summary>
        /// Sent when closing connection because of Tor protocol violations.
        /// </summary>
        REASON_TORPROTOCOL = 13,

        /// <summary>
        /// Client sent RELAY_BEGIN_DIR to a non-directory relay.
        /// </summary>
        REASON_NOTDIRECTORY = 14
    }
}