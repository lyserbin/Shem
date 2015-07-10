using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class AuthDirNewDescsEvent : AsyncEvent
    {
        public AuthDirNewDescsEvent()
        {

        }

        public override AsyncEvents Event
        {
            get { return AsyncEvents.AUTHDIR_NEWDESCS; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            //TODO: Implement parsing
            throw new System.NotImplementedException();
        }
    }
}