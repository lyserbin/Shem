
namespace Shem.AsyncEvents
{
    public class NoticeEvent : LogEvent
    {
        public NoticeEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.NOTICE; }
        }
    }
}