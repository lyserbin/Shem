using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class StatusGeneralEvent : TorEvent
    {
        public StatusGeneralEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.STATUS_GENERAL; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            base.ParseToEvent(reply);
        }
    }
}