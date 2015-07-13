using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class BwEvent : TorEvent
    {
        public BwEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.BW; }
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