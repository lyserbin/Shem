
namespace Shem.Commands
{
    /// <summary>
    /// document this
    /// </summary>
    public class MapAddress : TCCommand
    {
        private string oldAddress;

        private string newAddress;

        /// <summary>
        /// document this
        /// </summary>
        /// <param name="oldAddress"></param>
        /// <param name="newAddress"></param>
        public MapAddress(string oldAddress, string newAddress)
        {
            this.newAddress = newAddress;
            this.oldAddress = oldAddress;
        }

        public override string Raw()
        {
            return string.Format("MAPADDRESS {0}={1}", oldAddress, newAddress);
        }
    }
}
