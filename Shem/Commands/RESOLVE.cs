
namespace Shem.Commands
{
    /// <summary>
    /// This command launches a remote hostname lookup request for every specified request. Note that the request is done in the background: to see the answers, your controller will need to listen for ADDRMAP events.
    /// </summary>
    public class RESOLVE : TCCommand
    {
        private string address;
        private bool reverse;

        /// <summary>
        /// This command launches a remote hostname lookup request for every specified request.
        /// </summary>
        /// <param name="address">A hostname or IPv4 address</param>
        /// <param name="reverse"></param>
        public RESOLVE(string address, bool reverse = false)
        {
            //TODO: Pay attention, this command does not receive a synchronous reply.
            this.address = address;
            this.reverse = reverse;
        }

        public override string Raw()
        {
            return string.Format("RESOLVE{1} {0}\r\n", address, reverse ? "mode=reverse" : "");
        }
    }
}