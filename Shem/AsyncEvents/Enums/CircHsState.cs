
namespace Shem.AsyncEvents
{
    public enum CircHsState
    {
        /// <summary>
        /// Connecting to intro point
        /// </summary>
        HSCI_CONNECTING,

        /// <summary>
        /// Sent INTRODUCE1; waiting for reply from IP
        /// </summary>
        HSCI_INTRO_SENT,

        /// <summary>
        /// Received reply from IP relay; closing
        /// </summary>
        HSCI_DONE,

        /// <summary>
        /// Connecting to or waiting for reply from RP
        /// </summary>
        HSCR_CONNECTING,

        /// <summary>
        /// Established RP; waiting for introduction
        /// </summary>
        HSCR_ESTABLISHED_IDLE,

        /// <summary>
        /// Introduction sent to HS; waiting for rend
        /// </summary>
        HSCR_ESTABLISHED_WAITING,

        /// <summary>
        /// Connected to HS
        /// </summary>
        HSCR_JOINED,

        /// <summary>
        /// Connecting to intro point
        /// </summary>
        HSSI_CONNECTING,

        /// <summary>
        /// Established intro point
        /// </summary>
        HSSI_ESTABLISHED,

        /// <summary>
        /// Connecting to client's rend point
        /// </summary>
        HSSR_CONNECTING,

        /// <summary>
        /// Connected to client's RP circuit
        /// </summary>
        HSSR_JOINED
    }
}