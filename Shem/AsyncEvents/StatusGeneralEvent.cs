using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class StatusGeneralEvent : TorEvent
    {
        public StatusGeneralEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.STATUS_GENERAL; }
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