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
            base.ParseToEvent(reply);
        }
    }
}