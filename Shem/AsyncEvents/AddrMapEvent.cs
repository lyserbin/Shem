using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class AddrMapEvent : TorEvent
    {
        public AddrMapEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.ADDRMAP; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            base.ParseToEvent(reply);
        }
    }
}