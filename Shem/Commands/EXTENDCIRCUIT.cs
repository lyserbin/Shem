
namespace Shem.Commands
{
    /// <summary>
    /// Builds a new circuit or extends an existing one.
    /// </summary>
    public class EXTENDCIRCUIT : TCCommand
    {
        private string circuitID;
        private string[] serverSpecs;
        private string purpose;

        /// <summary>
        /// Builds a new circuit or extends an existing one.
        /// </summary>
        /// <param name="circuitID">If the CircuitID is zero it is a request for the server to build a new circuit, if the CircuitID is nonzero it is a request for the server to extend an existing circuit with that ID according to the specified path.</param>
        /// <param name="purpose"></param>
        /// <param name="serverSpecs"></param>
        public EXTENDCIRCUIT(string circuitID = "0", string purpose = "", params string[] serverSpecs)
        {
            this.circuitID = circuitID;
            this.purpose = purpose;
            this.serverSpecs = serverSpecs;
        }

        public override string Raw()
        {
            string serverSpecsFormatted = "";
            if (serverSpecs.Length > 0)
            {
                serverSpecsFormatted += serverSpecs[0];
                if (serverSpecs.Length > 1)
                {
                    for (int i = 1; i < serverSpecs.Length; i++)
                    {
                        serverSpecsFormatted += string.Format(" ,{0}", serverSpecs[i]);
                    }
                }
            }

            return string.Format("EXTENDCIRCUIT {0} {1} purpose={2}", circuitID, serverSpecsFormatted, purpose);
        }
    }
}