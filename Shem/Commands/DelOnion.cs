
namespace Shem.Commands
{
    /// <summary>
    /// Tells the server to remove an Onion ("Hidden") Service, that was previously created via an "ADD_ONION" command.  It is only possible to remove Onion Services that were created on the same control connection as the "DEL_ONION" command, and those that belong to no control connection in particular (The "Detach" flag was specified at creation).
    /// </summary>
    public class DelOnion : TCCommand
    {
        private string serviceID;

        /// <summary>
        /// Tells the server to remove an Onion ("Hidden") Service, that was previously created via an "ADD_ONION" command.  It is only possible to remove Onion Services that were created on the same control connection as the "DEL_ONION" command, and those that belong to no control connection in particular (The "Detach" flag was specified at creation).
        /// </summary>
        /// <param name="serviceID">The Onion Service address without the trailing ".onion" suffix</param>
        public DelOnion(string serviceID)
        {
            this.serviceID = serviceID;
        }

        public override string Raw()
        {
            return string.Format("DEL_ONION {0}\r\n", serviceID);
        }
    }
}