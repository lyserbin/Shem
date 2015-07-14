
namespace Shem.AsyncEvents
{
    public class HsDescEvent : TorEvent
    {
        public HsDescEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.HS_DESC; }
        }

        protected override void ParseToEvent(Replies.Reply reply)
        {
            base.ParseToEvent(reply);
        }
    }
}