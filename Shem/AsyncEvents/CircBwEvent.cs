
namespace Shem.AsyncEvents
{
    public class CircBwEvent : TorEvent
    {
        public CircBwEvent()
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