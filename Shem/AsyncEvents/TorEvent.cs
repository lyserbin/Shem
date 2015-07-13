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

        /// <summary>
        /// 
        /// </summary>
        public abstract TorEvents Event { get; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string RawString { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string EventLine { get; protected set; }

        protected virtual void ParseToEvent(Reply reply)
        {
            RawString = reply.RawString;
            EventLine = reply.ReplyLine.Substring(reply.ReplyLine.IndexOf(" "));
        }

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