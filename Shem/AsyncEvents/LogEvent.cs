using Shem.Replies;

namespace Shem.AsyncEvents
{
    public abstract class LogEvent : TorEvent
    {
        public LogEvent()
        {

        }

        private string logMessage = "";
        public string LogMessage
        {
            get { return logMessage; }
        }

        private string rawString = "";
        public override string RawString
        {
            get { return rawString; }
        }

        private string eventLine = "";
        public override string EventLine
        {
            get { return eventLine; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            rawString = reply.RawString;
            eventLine = reply.ReplyLine.Substring(reply.ReplyLine.IndexOf(" "));
            logMessage = eventLine;
        }
    }
}
