
namespace Shem.AsyncEvents
{
    public enum CircReasons
    {
        NONE,
        TORPROTOCOL,
        INTERNAL,
        REQUESTED,
        HIBERNATING,
        RESOURCELIMIT,
        CONNECTFAILED,
        OR_IDENTITY,
        OR_CONN_CLOSED,
        TIMEOUT,
        FINISHED,
        DESTROYED,

        /// <summary>
        /// Not enough nodes to make circuit
        /// </summary>
        NOPATH,
        NOSUCHSERVICE,

        /// <summary>
        /// As "TIMEOUT", except that we had left the circuit open for measurement purposes to see how long it would take to finish.
        /// </summary>
        MEASUREMENT_EXPIRED
    }
}