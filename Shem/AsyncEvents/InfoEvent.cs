using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class InfoEvent : AsyncEvent
    {
        public InfoEvent()
        {

        }

        public override AsyncEvents Event
        {
            get { return AsyncEvents.INFO; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            //TODO: Implement parsing
            throw new System.NotImplementedException();
        }
    }
}