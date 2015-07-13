
namespace Shem.AsyncEvents
{
    public class ErrEvent : LogEvent
    {
        public ErrEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.ERR; }
        }
    }
}