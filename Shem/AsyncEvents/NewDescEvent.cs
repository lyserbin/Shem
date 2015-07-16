using System.Collections.Generic;
using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class NewDescEvent : TorEvent
    {
        public NewDescEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.NEWDESC; }
        }

        public List<string> ServerIDs
        {
            get;
            protected set;
        }

        protected override void ParseToEvent(Reply reply)
        {
            base.ParseToEvent(reply);

            ServerIDs = new List<string>();
            ServerIDs.AddRange(EventLine.Split(' '));
        }
    }
}