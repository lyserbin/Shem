
namespace Shem.Commands
{
    public enum CircStatus
    {
        /// <summary>
        /// Circuit ID assigned to new circuit
        /// </summary>
        LAUNCHED,

        /// <summary>
        /// All hops finished, can now accept streams
        /// </summary>
        BUILT,

        /// <summary>
        /// One more hop has been completed
        /// </summary>
        EXTENDED,

        /// <summary>
        /// Circuit closed (was not built)
        /// </summary>
        FAILED,

        /// <summary>
        /// Circuit closed (was built)
        /// </summary>
        CLOSED
    }
}