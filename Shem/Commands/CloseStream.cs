
namespace Shem.Commands
{
    /// <summary>
    /// Tells the server to close the specified stream.
    /// </summary>
    public class CloseStream : TCCommand
    {
        private string streamID;
        private RelayEnd reason;

        /// <summary>
        /// Tells the server to close the specified stream.
        /// </summary>
        /// <param name="streamID"></param>
        /// <param name="reason">The reason should be one of the Tor RELAY_END.</param>
        public CloseStream(string streamID, RelayEnd reason)
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