
namespace Shem.Commands
{
    /// <summary>
    /// Tells the server to drop all guard nodes. Do not invoke this command lightly; it can increase vulnerability to tracking attacks over time.
    /// </summary>
    public class DROPGUARDS : TCCommand
    {
        /// <summary>
        /// Tells the server to drop all guard nodes. Do not invoke this command lightly; it can increase vulnerability to tracking attacks over time.
        /// </summary>
        public DROPGUARDS()
        {

        }

        public override string Raw()
        {
            return string.Format("DROPGUARDS\r\n");
        }
    }
}