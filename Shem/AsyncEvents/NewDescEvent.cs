using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class NewDescEvent : AsyncEvent
    {
        public NewDescEvent()
        {

        }

        public override AsyncEvents Event
        {
            get { return AsyncEvents.NEWDESC; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            //TODO: Implement parsing
            throw new System.NotImplementedException();
        }
    }
}