using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class StatusClientEvent : StatusEvent
    {
        public StatusClientEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.STATUS_CLIENT; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            base.ParseToEvent(reply);
        }
    }
}