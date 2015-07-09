
namespace Shem.Commands
{
    public enum CircPurpose
    {
        /// <summary>
        /// Circuit for AP and/or directory request streams
        /// </summary>
        GENERAL,

        /// <summary>
        /// HS client-side introduction-point circuit
        /// </summary>
        HS_CLIENT_INTRO,

        /// <summary>
        /// HS client-side rendezvous circuit; carries AP streams
        /// </summary>
        HS_CLIENT_REND,

        /// <summary>
        /// HS service-side introduction-point circuit
        /// </summary>
        HS_SERVICE_INTRO,

        /// <summary>
        /// HS service-side rendezvous circuit
        /// </summary>
        HS_SERVICE_REND,

        /// <summary>
        /// Reachability-testing circuit; carries no traffic
        /// </summary>
        TESTING,

        /// <summary>
        /// Circuit built by a controller
        /// </summary>
        CONTROLLER,

        /// <summary>
        /// circuit being kept around to see how long it takes
        /// </summary>
        MEASURE_TIMEOUT
    }
}