using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class ClientsSeenEvent : TorEvent
    {
        public ClientsSeenEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.CLIENTS_SEEN; }
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
