
namespace Shem.AsyncEvents
{
    public class WarnEvent : LogEvent
    {
        public WarnEvent()
        {

        }

        public override AsyncEvents Event
        {
            get { return AsyncEvents.WARN; }
        }
    }
}