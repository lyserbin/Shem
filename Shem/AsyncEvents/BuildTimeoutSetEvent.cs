using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class BuildTimeoutSetEvent : TorEvent
    {
        public BuildTimeoutSetEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.BUILDTIMEOUT_SET; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            base.ParseToEvent(reply);
        }
    }
}