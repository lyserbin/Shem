
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
    }
}