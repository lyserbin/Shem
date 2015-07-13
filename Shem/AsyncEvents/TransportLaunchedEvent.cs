
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
    }
}