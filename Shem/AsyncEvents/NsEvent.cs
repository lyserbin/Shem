using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class NsEvent : TorEvent
    {
        public NsEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.NS; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            base.ParseToEvent(reply);
        }
    }
}