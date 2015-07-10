using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class CircMinorEvent : AsyncEvent
    {
        public CircMinorEvent()
        {

        }

        public override AsyncEvents Event
        {
            get { return AsyncEvents.CIRC_MINOR; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            //TODO: Implement parsing
            throw new System.NotImplementedException();
        }
    }
}
