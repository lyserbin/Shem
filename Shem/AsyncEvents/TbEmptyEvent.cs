
namespace Shem.AsyncEvents
{
    /// <summary>
    /// This event is generated when refilling a previously empty token bucket.
    /// </summary>
    public class TbEmptyEvent : TorEvent
    {
        public TbEmptyEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.TB_EMPTY; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string ConnectionID
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public int ReadBucket
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public int WriteBucket
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public int LastRefill
        {
            get;
            protected set;
        }

        protected override void ParseToEvent(Replies.Reply reply)
        {
            base.ParseToEvent(reply);

            int index = 0;
            string[] split = EventLine.Split(' ');

            Name = split[index];
            index++;

            for (int i = index; i < split.Length; i++)
            {
                if (split[i].Contains("="))
                {
                    string key = split[i].Split('=')[0];
                    string value = split[i].Split('=')[1];

                    switch (key.ToUpper())
                    {
                        case "ID":
                            ConnectionID = value;
                            break;
                        case "READ":
                            int r = 0;
                            int.TryParse(value, out r);
                            ReadBucket = r;
                            break;
                        case "WRITTEN":
                            int w = 0;
                            int.TryParse(value, out w);
                            WriteBucket = w;
                            break;
                        case "LAST":
                            int l = 0;
                            int.TryParse(value, out l);
                            LastRefill = l;
                            break;
                    }
                }
            }
        }
    }
}