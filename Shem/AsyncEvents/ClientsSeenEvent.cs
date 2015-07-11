using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class ClientsSeenEvent : AsyncEvent
    {
        public ClientsSeenEvent()
        {

        }

        public override AsyncEvents Event
        {
            get { return AsyncEvents.CLIENTS_SEEN; }
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
