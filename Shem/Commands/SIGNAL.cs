
namespace Shem.Commands
{
    public class SIGNAL : TCCommand
    {
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
