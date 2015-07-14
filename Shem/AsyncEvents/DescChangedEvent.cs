using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class DescChangedEvent : TorEvent
    {
        public DescChangedEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.DESCCHANGED; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            base.ParseToEvent(reply);
        }
    }
}