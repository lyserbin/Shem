using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class StreamBwEvent : TorEvent
    {
        public StreamBwEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.STREAM_BW; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            base.ParseToEvent(reply);
        }
    }
}