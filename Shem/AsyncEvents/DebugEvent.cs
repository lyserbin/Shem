
namespace Shem.AsyncEvents
{
    public class DebugEvent : LogEvent
    {
        public DebugEvent()
        {

        }

        public override AsyncEvents Event
        {
            get { return AsyncEvents.DEBUG; }
        }
    }
}