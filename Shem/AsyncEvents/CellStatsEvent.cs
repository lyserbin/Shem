
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
    }
}