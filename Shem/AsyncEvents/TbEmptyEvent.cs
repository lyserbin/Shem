
namespace Shem.AsyncEvents
{
    public class TbEmptyEvent : TorEvent
    {
        public TbEmptyEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.TB_EMPTY; }
        }

        protected override void ParseToEvent(Replies.Reply reply)
        {
            base.ParseToEvent(reply);
        }
    }
}