using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class NewConsensusEvent : TorEvent
    {
        public NewConsensusEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.NEWCONSENSUS; }
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