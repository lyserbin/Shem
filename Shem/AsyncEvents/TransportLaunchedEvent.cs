
namespace Shem.AsyncEvents
{
    public class TransportLaunchedEvent : TorEvent
    {
        public TransportLaunchedEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.TRANSPORT_LAUNCHED; }
        }

        protected override void ParseToEvent(Replies.Reply reply)
        {
            base.ParseToEvent(reply);
        }
    }
}