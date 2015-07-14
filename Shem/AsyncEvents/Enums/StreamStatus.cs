
namespace Shem.AsyncEvents
{
    public enum StreamStatus
    {
        /// <summary>
        /// New request to connect
        /// </summary>
        NEW,

        /// <summary>
        /// New request to resolve an address 
        /// </summary>
        NEWRESOLVE,

        /// <summary>
        /// Address re-mapped to another 
        /// </summary>
        REMAP,

        /// <summary>
        /// Sent a connect cell along a circuit 
        /// </summary>
        SENTCONNECT,

        /// <summary>
        /// Sent a resolve cell along a circuit 
        /// </summary>
        SENTRESOLVE,

        /// <summary>
        /// Received a reply stream established 
        /// </summary>
        SUCCEEDED,

        /// <summary>
        /// Stream failed and not retriable 
        /// </summary>
        FAILED,
        /// <summary>
        /// Stream closed 
        /// </summary>
        CLOSED,

        /// <summary>
        /// Detached from circuit still retriable 
        /// </summary>
        DETACHED
    }
}