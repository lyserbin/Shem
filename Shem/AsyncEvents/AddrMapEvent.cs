using System;
using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class AddrMapEvent : AsyncEvent
    {
        public AddrMapEvent()
        {

        }

        public override AsyncEvents Event
        {
            get { return AsyncEvents.ADDRMAP; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            //TODO: Implement parsing
            throw new NotImplementedException();
        }
    }
}