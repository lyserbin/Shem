using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class OrConnEvent : TorEvent
    {
        public OrConnEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.ORCONN; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            base.ParseToEvent(reply);
        }
    }
}