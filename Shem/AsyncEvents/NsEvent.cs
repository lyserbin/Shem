using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class NsEvent : AsyncEvent
    {
        public NsEvent()
        {

        }

        public override AsyncEvents Event
        {
            get { return AsyncEvents.NS; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            //TODO: Implement parsing
            throw new System.NotImplementedException();
        }
    }
}