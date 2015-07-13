using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class OrConnEvent : TorEvent
    {
        public OrConnEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.ORCONN; }
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