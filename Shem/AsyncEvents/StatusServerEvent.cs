using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class StatusServerEvent : AsyncEvent
    {
        public StatusServerEvent()
        {

        }

        public override AsyncEvents Event
        {
            get { return AsyncEvents.STATUS_SERVER; }
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