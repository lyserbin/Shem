using System;
using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class AddrMapEvent : TorEvent
    {
        public AddrMapEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.ADDRMAP; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            //TODO: Implement parsing
            throw new NotImplementedException();
        }

        public override string RawString
        {
            get { throw new NotImplementedException(); }
        }

        public override string EventLine
        {
            get { throw new NotImplementedException(); }
        }
    }
}