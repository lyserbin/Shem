
namespace Shem.AsyncEvents
{
    public class CellStatsEvent : TorEvent
    {
        public CellStatsEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.CELL_STATS; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ID
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string InboundQueue
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string InboundConn
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string InboundAdded
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string InboundRemoved
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string InboundTime
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string OutboundQueue
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string OutboundConn
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string OutboundAdded
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string OutboundRemoved
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string OutboundTime
        {
            get;
            protected set;
        }

        protected override void ParseToEvent(Replies.Reply reply)
        {
            base.ParseToEvent(reply);

            int index = 0;
            string[] split = EventLine.Split(' ');

            for (int i = index; i < split.Length; i++)
            {
                if (split[i].Contains("="))
                {
                    string key = split[i].Split('=')[0];
                    string value = split[i].Split('=')[1];

                    switch (key.ToUpper())
                    {
                        case "ID":
                            ID = value;
                            break;
                        case "INBOUNDQUEUE":
                            InboundQueue = value;
                            break;
                        case "INBOUNDCONN":
                            InboundConn = value;
                            break;
                        case "INBOUNDADDED":
                            InboundAdded = value;
                            break;
                        case "INBOUNDREMOVED":
                            InboundRemoved = value;
                            break;
                        case "INBOUNDTIME":
                            InboundTime = value;
                            break;
                        case "OUTBOUNDQUEUE":
                            OutboundQueue = value;
                            break;
                        case "OUTBOUNDCONN":
                            OutboundConn = value;
                            break;
                        case "OUTBOUNDADDED":
                            OutboundAdded = value;
                            break;
                        case "OUTBOUNDREMOVED":
                            OutboundRemoved = value;
                            break;
                        case "OUTBOUNDTIME":
                            OutboundTime = value;
                            break;
                    }
                }
            }
        }
    }
}