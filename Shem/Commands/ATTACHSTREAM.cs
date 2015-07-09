
namespace Shem.Commands
{
    /// <summary>
    /// This message informs the server that the specified stream should be associated with the specified circuit.  Each stream may be associated with at most one circuit, and multiple streams may share the same circuit. Streams can only be attached to completed circuits (that is, circuits that have sent a circuit status 'BUILT' event or are listed as built in a GETINFO circuit-status request).
    /// </summary>
    public class AttachStream : TCCommand
    {
        private string streamID;
        private string circuitID;
        private string hop = "";

        /// <summary>
        /// This message informs the server that the specified stream should be associated with the specified circuit.  Each stream may be associated with at most one circuit, and multiple streams may share the same circuit. Streams can only be attached to completed circuits (that is, circuits that have sent a circuit status 'BUILT' event or are listed as built in a GETINFO circuit-status request).
        /// </summary>
        /// <param name="streamID"></param>
        /// <param name="circuitID">If the circuit ID is 0, responsibility for attaching the given stream is returned to Tor.</param>
        /// <param name="hop">If HOP=HopNum is specified, Tor will choose the HopNumth hop in the circuit as the exit node, rather than the last node in the circuit. Hops are 1-indexed; generally, it is not permitted to attach to hop 1.</param>
        public AttachStream(string streamID, string circuitID, string hop = "")
        {
            this.circuitID = circuitID;
            this.streamID = streamID;
            this.hop = hop;
        }

        public override string Raw()
        {
            return string.Format("ATTACHSTREAM {0} {1}{2}\r\n", streamID, circuitID, hop != "" ? " HOP=" + hop : "");
        }
    }
}