
namespace Shem.Commands
{
    /// <summary>
    /// This command instructs Tor to shut down when this control connection is closed.  This command affects each control connection that sends it independently; if multiple control connections send the TAKEOWNERSHIP command to a Tor instance, Tor will shut down when any of those connections closes.
    /// </summary>
    public class TAKEOWNERSHIP : TCCommand
    {
        /// <summary>
        /// This command instructs Tor to shut down when this control connection is closed.  This command affects each control connection that sends it independently; if multiple control connections send the TAKEOWNERSHIP command to a Tor instance, Tor will shut down when any of those connections closes.
        /// </summary>
        public TAKEOWNERSHIP()
        {

        }

        public override string Raw()
        {
            return string.Format("TAKEOWNERSHIP\r\n");
        }
    }
}