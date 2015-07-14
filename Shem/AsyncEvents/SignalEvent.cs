using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class SignalEvent : TorEvent
    {
        public SignalEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.SIGNAL; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            base.ParseToEvent(reply);
        }
    }
}