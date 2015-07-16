
namespace Shem.AsyncEvents
{
    /// <summary>
    /// Bandwidth used by all streams attached to a circuit
    /// </summary>
    public class CircBwEvent : TorEvent
    {
        public CircBwEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.CONN_BW; }
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
        public int BytesRead
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public int BytesWritten
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
                        case "READ":
                            int r = 0;
                            int.TryParse(value, out r);
                            BytesRead = r;
                            break;
                        case "WRITTEN":
                            int w = 0;
                            int.TryParse(value, out w);
                            BytesWritten = w;
                            break;
                    }
                }
            }
        }
    }
}