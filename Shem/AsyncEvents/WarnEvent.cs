
namespace Shem.AsyncEvents
{
    public class WarnEvent : LogEvent
    {
        public WarnEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.WARN; }
        }
    }
}