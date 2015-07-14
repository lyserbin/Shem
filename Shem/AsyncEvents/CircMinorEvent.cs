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
            base.ParseToEvent(reply);
        }
    }
}
