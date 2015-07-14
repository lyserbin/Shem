
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

        protected override void ParseToEvent(Replies.Reply reply)
        {
            base.ParseToEvent(reply);
        }
    }
}