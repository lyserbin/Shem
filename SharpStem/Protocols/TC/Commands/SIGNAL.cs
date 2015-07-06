
namespace SharpStem.Protocols.TC.Commands
{
    public class SIGNAL : TCCommand
    {
        public enum Signals
        {
            RELOAD, SHUTDOWN, DUMP, DEBUG, HALT, HUP, INT, USR1, USR2, TERM, NEWNYM, CLEARDNSCACHE, HEARTBEAT
        }

        private Signals signal;

        public SIGNAL(Signals signal)
        {
            this.signal = signal;
        }

        public override string Raw()
        {
            return string.Format("SIGNAL {0}\r\n", signal.ToString());
        }
    }
}
