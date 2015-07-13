using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class StatusSeverEvent : AsyncEvent
    {
        public StatusSeverEvent()
        {

        }

        public override AsyncEvents Event
        {
            get { return AsyncEvents.STATUS_SEVER; }
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