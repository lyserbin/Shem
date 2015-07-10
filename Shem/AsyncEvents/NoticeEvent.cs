using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class NoticeEvent : AsyncEvent
    {
        public NoticeEvent()
        {

        }

        public override AsyncEvents Event
        {
            get { return AsyncEvents.NOTICE; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            //TODO: Implement parsing
            throw new System.NotImplementedException();
        }
    }
}