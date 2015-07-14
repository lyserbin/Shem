using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class StreamEvent : TorEvent
    {
        public StreamEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.STREAM; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            base.ParseToEvent(reply);
        }
    }
}