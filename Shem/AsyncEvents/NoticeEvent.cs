
namespace Shem.AsyncEvents
{
    public class NoticeEvent : LogEvent
    {
        public NoticeEvent()
        {

        }

        public override AsyncEvents Event
        {
            get { return AsyncEvents.NOTICE; }
        }
    }
}