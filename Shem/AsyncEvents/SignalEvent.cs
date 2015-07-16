using Shem.Replies;

namespace Shem.AsyncEvents
{
    /// <summary>
    /// A signal has been received and actions taken by Tor.
    /// </summary>
    public class SignalEvent : TorEvent
    {
        public SignalEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.SIGNAL; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Signal
        {
            get;
            protected set;
        }

        protected override void ParseToEvent(Reply reply)
        {
            base.ParseToEvent(reply);

            Signal = EventLine;
        }
    }
}