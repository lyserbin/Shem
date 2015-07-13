using Shem.Replies;

namespace Shem.AsyncEvents
{
    public abstract class LogEvent : TorEvent
    {
        public LogEvent()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public string LogMessage
        {
            get;
            protected set;
        }

        protected override void ParseToEvent(Reply reply)
        {
            base.ParseToEvent(reply);
            LogMessage = EventLine;
        }
    }
}
