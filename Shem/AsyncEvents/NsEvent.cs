using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class NsEvent : TorEvent
    {
        public NsEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.NS; }
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