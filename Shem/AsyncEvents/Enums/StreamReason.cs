
namespace Shem.AsyncEvents
{
    public enum StreamReason
    {
        MISC,
        RESOLVEFAILED,
        CONNECTREFUSED,
        EXITPOLICY,
        DESTROY,
        DONE,
        TIMEOUT,
        NOROUTE,
        HIBERNATING,
        INTERNAL,
        RESOURCELIMIT,
        CONNRESET,
        TORPROTOCOL,
        NOTDIRECTORY,
        /// <summary>
        /// We received a RELAY_END cell from the other side of this stream.
        /// </summary>
        END,
        /// <summary>
        /// The client tried to connect to a private address like 127.0.0.1 or 10.0.0.1 over Tor.
        /// </summary>
        PRIVATE_ADDR
    }
}