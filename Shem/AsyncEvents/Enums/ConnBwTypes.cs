
namespace Shem.AsyncEvents
{
    public enum ConnBwTypes
    {
        /// <summary>
        /// Carrying traffic within the tor network. This can either be our own (client) traffic or traffic we're relaying within the network.
        /// </summary>
        OR,

        /// <summary>
        /// Fetching tor descriptor data, or transmitting descriptors we're mirroring.
        /// </summary>
        DIR,

        /// <summary>
        /// Carrying traffic between the tor network and an external destination.
        /// </summary>
        EXIT
    }
}