using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class ConfChangedEvent : TorEvent
    {
        public ConfChangedEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.CONF_CHANGED; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            base.ParseToEvent(reply);
        }
    }
}