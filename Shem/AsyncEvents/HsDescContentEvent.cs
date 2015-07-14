
namespace Shem.AsyncEvents
{
    public class HsDescContentEvent : TorEvent
    {
        public HsDescContentEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.HS_DESC_CONTENT; }
        }

        protected override void ParseToEvent(Replies.Reply reply)
        {
            base.ParseToEvent(reply);
        }
    }
}