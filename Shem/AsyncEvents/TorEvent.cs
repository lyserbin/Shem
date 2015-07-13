using System;
using Shem.Replies;
using Shem.Utils;

namespace Shem.AsyncEvents
{
    public abstract class TorEvent
    {
        protected TorEvent()
        {

        }

        public abstract TorEvents Event { get; }

        public abstract string RawString { get; }

        public abstract string EventLine { get; }

        protected abstract void ParseToEvent(Reply reply);

        public static TorEvent Parse(Reply reply)
        {
            string eventName = reply.ReplyLine.Substring(0, reply.ReplyLine.IndexOf(" "));
            TorEvents eventEnum = (TorEvents)Enum.Parse(typeof(TorEvents), eventName, true);

            Type eventType = eventEnum.GetTypeValue();
            if (eventType == null)
            {
                throw new NullReferenceException();
            }
            TorEvent asyncEvent = (TorEvent)Activator.CreateInstance(eventType);

            asyncEvent.ParseToEvent(reply);

            return asyncEvent;
        }
    }
}