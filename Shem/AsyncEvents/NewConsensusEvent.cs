﻿using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class NewConsensusEvent : AsyncEvent
    {
        public NewConsensusEvent()
        {

        }

        public override AsyncEvents Event
        {
            get { return AsyncEvents.NEWCONSENSUS; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            //TODO: Implement parsing
            throw new System.NotImplementedException();
        }
    }
}