using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class BuildTimeoutSetEvent : AsyncEvent
    {
        public BuildTimeoutSetEvent()
        {

        }

        public override AsyncEvents Event
        {
            get { return AsyncEvents.BUILDTIMEOUT_SET; }
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