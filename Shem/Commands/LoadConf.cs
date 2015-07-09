
namespace Shem.Commands
{
    /// <summary>
    /// This command allows a controller to upload the text of a config file to Tor over the control port. This config file is then loaded as if it had been read from disk.
    /// </summary>
    public class LoadConf : TCCommand
    {
        private string configtext;
        /// <summary>
        /// This command allows a controller to upload the text of a config file to Tor over the control port. This config file is then loaded as if it had been read from disk.
        /// </summary>
        /// <param name="configtext"></param>
        public LoadConf(string configtext)
        {
            this.configtext = configtext;
        }

        public override string Raw()
        {
            return string.Format("+LOADCONF\r\n{0}\r\n.\r\n", configtext);
        }
    }
}