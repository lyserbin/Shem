using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class GuardEvent : AsyncEvent
    {
        public GuardEvent()
        {

        }

        public override AsyncEvents Event
        {
            get { return AsyncEvents.GUARD; }
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