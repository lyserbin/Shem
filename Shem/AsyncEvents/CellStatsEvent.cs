
namespace Shem.AsyncEvents
{
    public class CellStatsEvent : TorEvent
    {
        public CellStatsEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.CELL_STATS; }
        }

        protected override void ParseToEvent(Replies.Reply reply)
        {
            base.ParseToEvent(reply);
        }
    }
}