
namespace Shem.Commands
{
    /// <summary>
    ///  Tells the server to change the exit address on the specified stream, no remapping is performed on the new provided address.
    /// </summary>
    public class RedirectStream : TCCommand
    {
        private string streamID;
        private string address;
        private string port;

        /// <summary>
        /// Tells the server to change the exit address on the specified stream.To be sure that the modified address will be used, this event must be sent after a new stream event is received, and before attaching this stream to a circuit.
        /// </summary>
        /// <param name="streamID"></param>
        /// <param name="address"></param>
        /// <param name="port">If Port is specified, changes the destination port as well.</param>
        public RedirectStream(string streamID, string address, string port = "")
        {
            this.address = address;
            this.streamID = streamID;
            this.port = port;
        }

        public override string Raw()
        {
            return string.Format("REDIRECTSTREAM {0} {1}{2}\r\n", streamID, address, port != "" ? " " + port : "");
        }
    }
}