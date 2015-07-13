
namespace Shem.AsyncEvents
{
    /// <summary>
    /// 
    /// </summary>
    public class ErrEvent : LogEvent
    {
        public ErrEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.ERR; }
        }
    }
}