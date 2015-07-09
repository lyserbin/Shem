
namespace Shem.Commands
{
    /// <summary>
    /// Send a signal to the server.
    /// </summary>
    public class Signal : TCCommand
    {
        private Signals signal;

        /// <summary>
        /// Send a signal to the server.
        /// </summary>
        /// <param name="signal"></param>
        public Signal(Signals signal)
        {
            this.signal = signal;
        }

        public override string Raw()
        {
            return string.Format("SIGNAL {0}\r\n", signal.ToString());
        }
    }
}
