using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class AuthDirNewDescsEvent : TorEvent
    {
        public AuthDirNewDescsEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.AUTHDIR_NEWDESCS; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            base.ParseToEvent(reply);
        }
    }
}