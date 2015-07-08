using Shem.Commands.Enums;

namespace Shem.Commands
{
    /// <summary>
    /// Tells the server to close the specified stream.
    /// </summary>
    public class CLOSESTREAM : TCCommand
    {
        private string streamID;
        private RELAY_END reason;

        /// <summary>
        /// Tells the server to close the specified stream.
        /// </summary>
        /// <param name="streamID"></param>
        /// <param name="reason">The reason should be one of the Tor RELAY_END.</param>
        public CLOSESTREAM(string streamID, RELAY_END reason)
        {
            this.streamID = streamID;
            this.reason = reason;
        }

        public override string Raw()
        {
            return string.Format("CLOSESTREAM {0} {1}\r\n", streamID, ((int)reason).ToString());
        }
    }
}