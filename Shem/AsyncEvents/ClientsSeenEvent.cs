using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class ClientsSeenEvent : TorEvent
    {
        public ClientsSeenEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.CLIENTS_SEEN; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            base.ParseToEvent(reply);
        }
    }
}
