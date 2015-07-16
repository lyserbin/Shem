
namespace Shem.AsyncEvents
{
    /// <summary>
    /// Network liveness has changed
    /// </summary>
    public class NetworkLivenessEvent : TorEvent
    {
        public NetworkLivenessEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.NETWORK_LIVENESS; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Status
        {
            get;
            protected set;
        }

        protected override void ParseToEvent(Replies.Reply reply)
        {
            base.ParseToEvent(reply);

            Status = EventLine;
        }
    }
}