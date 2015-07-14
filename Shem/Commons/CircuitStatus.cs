namespace Shem.Commons
{
    /// <summary>
    /// Enum representing the status of the circuit
    /// </summary>
    public enum CircuitStatus
    {
        /// <summary>
        /// circuit ID assigned to new circuit
        /// </summary>
        LAUNCHED,

        /// <summary>
        /// all hops finished, can now accept streams
        /// </summary>
        BUILT,

        /// <summary>
        /// one more hop has been completed
        /// </summary>
        EXTENDED,

        /// <summary>
        /// circuit closed (was not built)
        /// </summary>
        FAILED,

        /// <summary>
        /// circuit closed (was built)
        /// </summary>
        CLOSED
    }
}
