using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class NewDescEvent : TorEvent
    {
        public NewDescEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.NEWDESC; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            base.ParseToEvent(reply);
        }
    }
}