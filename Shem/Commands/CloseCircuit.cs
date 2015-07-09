
namespace Shem.Commands
{
    /// <summary>
    /// Tells the server to close the specified circuit.
    /// </summary>
    public class CloseCircuit : TCCommand
    {
        private string circuitID;
        private CloseCircuiteFlags[] flags;

        /// <summary>
        /// Tells the server to close the specified circuit.
        /// </summary>
        /// <param name="circuitID"></param>
        /// <param name="flags"></param>
        public CloseCircuit(string circuitID, params CloseCircuiteFlags[] flags)
        {
            this.circuitID = circuitID;
            this.flags = flags;
        }

        public override string Raw()
        {
            string formattedFlags = "";

            foreach (var f in flags)
            {
                formattedFlags += " " + f.ToString();
            }

            return string.Format("CLOSECIRCUIT {0}{1}\r\n", circuitID, formattedFlags);
        }
    }
}