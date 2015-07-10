using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class SignalEvent : AsyncEvent
    {
        public SignalEvent()
        {

        }

        public override AsyncEvents Event
        {
            get { return AsyncEvents.SIGNAL; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            //TODO: Implement parsing
            throw new System.NotImplementedException();
        }
    }
}