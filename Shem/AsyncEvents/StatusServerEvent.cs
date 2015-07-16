using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class StatusServerEvent : StatusEvent
    {
        public StatusServerEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.STATUS_SERVER; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            base.ParseToEvent(reply);
        }
    }
}