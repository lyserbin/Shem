using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class ErrEvent : AsyncEvent
    {
        public ErrEvent()
        {

        }

        public override AsyncEvents Event
        {
            get { return AsyncEvents.ERR; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            //TODO: Implement parsing
            throw new System.NotImplementedException();
        }
    }
}