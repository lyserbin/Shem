using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class StatusClientEvent : TorEvent
    {
        public StatusClientEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.STATUS_CLIENT; }
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