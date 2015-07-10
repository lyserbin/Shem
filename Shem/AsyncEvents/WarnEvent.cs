using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class WarnEvent : AsyncEvent
    {
        public WarnEvent()
        {

        }

        public override AsyncEvents Event
        {
            get { return AsyncEvents.WARN; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            //TODO: Implement parsing
            throw new System.NotImplementedException();
        }
    }
}