using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class CircEvent : AsyncEvent
    {
        public CircEvent()
        {

        }

        public override AsyncEvents Event
        {
            get { return AsyncEvents.CIRC; }
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