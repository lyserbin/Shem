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
            //TODO: Implement parsing
            throw new System.NotImplementedException();
        }

        public override string RawString
        {
            get { throw new System.NotImplementedException(); }
        }

        public override string EventLine
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}