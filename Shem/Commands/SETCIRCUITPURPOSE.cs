
namespace Shem.Commands
{
    /// <summary>
    /// This changes the circuit's purpose.
    /// </summary>
    public class SETCIRCUITPURPOSE : TCCommand
    {
        private string circuitID;
        private string purpose;

        /// <summary>
        /// This changes the circuit's purpose.
        /// </summary>
        /// <param name="circuitID"></param>
        /// <param name="purpose"></param>
        public SETCIRCUITPURPOSE(string circuitID, string purpose = "")
        {
            this.circuitID = circuitID;
            this.purpose = purpose;
        }

        public override string Raw()
        {
            return string.Format("SETCIRCUITPURPOSE {0} purpose={1}", circuitID, purpose);
        }
    }
}