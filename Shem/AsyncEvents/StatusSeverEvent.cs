using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class StatusSeverEvent : TorEvent
    {
        public StatusSeverEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.STATUS_SEVER; }
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