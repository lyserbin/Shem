
namespace Shem.Commands
{
    /// <summary>
    /// Save the current configs to the torrc.
    /// </summary>
    public class SaveConf : TCCommand
    {
        /// <summary>
        /// Returns the raw command.
        /// </summary>
        /// <returns></returns>
        public override string Raw()
        {
            return "SAVECONF\r\n";
        }
    }
}