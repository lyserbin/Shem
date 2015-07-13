
namespace Shem.AsyncEvents
{
    public class ErrEvent : LogEvent
    {
        public ErrEvent()
        {

        }

        public override AsyncEvents Event
        {
            get { return AsyncEvents.ERR; }
        }
    }
}