using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class CircMinorEvent : TorEvent
    {
        public CircMinorEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.CIRC_MINOR; }
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
