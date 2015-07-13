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
            //TODO: Implement parsing
            throw new System.NotImplementedException();
        }

        public override string RawString
        {
            get { throw new System.NotImplementedException(); }
        }

        public override string EventLine
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}