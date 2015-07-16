using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class ClientsSeenEvent : TorEvent
    {
        public ClientsSeenEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.CLIENTS_SEEN; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string TimeStarted
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string[] CountrySummary
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string[] IPVersions
        {
            get;
            protected set;
        }

        protected override void ParseToEvent(Reply reply)
        {
            base.ParseToEvent(reply);

            string[] split = EventLine.Split(' ');

            TimeStarted = split[0].Replace("\"", "");

            CountrySummary = split[1].Split(',');

            IPVersions = split[2].Split(',');
        }
    }
}
