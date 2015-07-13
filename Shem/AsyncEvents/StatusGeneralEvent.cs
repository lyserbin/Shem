using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class StatusGeneralEvent : AsyncEvent
    {
        public StatusGeneralEvent()
        {

        }

        public override AsyncEvents Event
        {
            get { return AsyncEvents.STATUS_GENERAL; }
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