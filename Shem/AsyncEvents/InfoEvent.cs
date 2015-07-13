
namespace Shem.AsyncEvents
{
    public class InfoEvent : LogEvent
    {
        public InfoEvent()
        {

        }

        public override AsyncEvents Event
        {
            get { return AsyncEvents.INFO; }
        }
    }
}