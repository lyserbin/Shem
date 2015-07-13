using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class ConfChangedEvent : TorEvent
    {
        public ConfChangedEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.CONF_CHANGED; }
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