
namespace Shem.AsyncEvents
{
    public class NetworkLivenessEvent : TorEvent
    {
        public NetworkLivenessEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.NETWORK_LIVENESS; }
        }

        protected override void ParseToEvent(Replies.Reply reply)
        {
            base.ParseToEvent(reply);
        }
    }
}