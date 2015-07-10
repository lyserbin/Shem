using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class DebugEvent : AsyncEvent
    {
        public DebugEvent()
        {

        }

        public override AsyncEvents Event
        {
            get { return AsyncEvents.DEBUG; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            //TODO: Implement parsing
            throw new System.NotImplementedException();
        }
    }
}