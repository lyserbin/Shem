using System;
using Shem.Replies;
using Shem.Utils;

namespace Shem.AsyncEvents
{
    public abstract class AsyncEvent
    {
        protected AsyncEvent()
        {

        }

        public abstract AsyncEvents Event { get; }

        protected abstract void ParseToEvent(Reply reply);

        public static AsyncEvent Parse(Reply reply)
        {
            string eventName = reply.ReplyLine.Substring(0, reply.ReplyLine.IndexOf(" "));
            AsyncEvents eventEnum = (AsyncEvents)Enum.Parse(typeof(AsyncEvents), eventName, true);

            Type eventType = eventEnum.GetTypeValue();
            if (eventType == null)
            {
                throw new NullReferenceException();
            }
            AsyncEvent asyncEvent = (AsyncEvent)Activator.CreateInstance(eventType);

            asyncEvent.ParseToEvent(reply);

            return asyncEvent;
        }
    }
}