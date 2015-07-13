
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
    }
}