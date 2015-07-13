
namespace Shem.AsyncEvents
{
    /// <summary>
    /// 
    /// </summary>
    public class WarnEvent : LogEvent
    {
        public WarnEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.WARN; }
        }
    }
}