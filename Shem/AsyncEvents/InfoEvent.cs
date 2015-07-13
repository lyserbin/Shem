
namespace Shem.AsyncEvents
{
    public class InfoEvent : LogEvent
    {
        public InfoEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.INFO; }
        }
    }
}