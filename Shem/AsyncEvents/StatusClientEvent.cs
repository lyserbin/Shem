using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class StatusClientEvent : AsyncEvent
    {
        public StatusClientEvent()
        {

        }

        public override AsyncEvents Event
        {
            get { return AsyncEvents.STATUS_CLIENT; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            //TODO: Implement parsing
            throw new System.NotImplementedException();
        }
    }
}