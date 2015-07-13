
namespace Shem.AsyncEvents
{
    public class ConnBwEvent : TorEvent
    {
        public ConnBwEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.CONN_BW; }
        }
    }
}