using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class ConfChangedEvent : AsyncEvent
    {
        public ConfChangedEvent()
        {

        }

        public override AsyncEvents Event
        {
            get { return AsyncEvents.CONF_CHANGED; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            //TODO: Implement parsing
            throw new System.NotImplementedException();
        }
    }
}