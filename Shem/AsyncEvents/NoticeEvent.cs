
namespace Shem.AsyncEvents
{
    /// <summary>
    /// 
    /// </summary>
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