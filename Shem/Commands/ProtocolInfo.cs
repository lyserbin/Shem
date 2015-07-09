namespace Shem.Commands
{
    /// <summary>
    /// Returns all information about the protocol. PROTOCOLINFO may be used (but only once!) before AUTHENTICATE.
    /// </summary>
    public class ProtocolInfo : TCCommand
    {
        private string PIVersion;

        /// <summary>
        /// Returns all information about the protocol. PROTOCOLINFO may be used (but only once!) before AUTHENTICATE.
        /// </summary>
        /// <param name="PIVersion">PIVERSION is there in case we drastically change the syntax one day. For now it should always be "1".  Controllers MAY provide a list of the protocolinfo versions they support; Tor MAY select a version that the controller does not support.</param>
        public ProtocolInfo(string PIVersion = "1")
        {
            this.PIVersion = PIVersion;
        }

        public override string Raw()
        {
            return string.Format("PROTOCOLINFO {0}\r\n", PIVersion);
        }
    }
}