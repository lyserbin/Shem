using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class StreamEvent : AsyncEvent
    {
        public StreamEvent()
        {

        }

        public override AsyncEvents Event
        {
            get { return AsyncEvents.STREAM; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            //TODO: Implement parsing
            throw new System.NotImplementedException();
        }
    }
}