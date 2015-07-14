using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class GuardEvent : TorEvent
    {
        public GuardEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.GUARD; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            base.ParseToEvent(reply);
        }
    }
}