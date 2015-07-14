using Shem.Replies;

namespace Shem.AsyncEvents
{
    /// <summary>
    /// These events are generated when a new address mapping is entered in Tor's address map cache, or when the answer for a RESOLVE command is found.  Entries can be created by a successful or failed DNS lookup, a successful or failed connection attempt, a RESOLVE command, a MAPADDRESS command, the AutomapHostsOnResolve feature, or the TrackHostExits feature.
    /// </summary>
    public class AddrMapEvent : TorEvent
    {
        public AddrMapEvent()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string NewAddress
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Expiry
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Error
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Expires
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Cached
        {
            get;
            protected set;
        }

        public override TorEvents Event
        {
            get { return TorEvents.ADDRMAP; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            base.ParseToEvent(reply);

            int index = 0;
            string[] split = EventLine.Split(' ');

            Address = split[index];
            index++;

            NewAddress = split[index];
            index++;

            Expiry = split[index].Replace("\"", "");
            index++;

            for (int i = index; i < split.Length; i++)
            {
                if (split[i].Contains("="))
                {
                    string key = split[i].Split('=')[0];
                    string value = split[i].Split('=')[1];

                    switch (key.ToUpper())
                    {
                        case "ERROR":
                            Error = value;
                            break;
                        case "EXPIRES":
                            Expires = value.Replace("\"", "");
                            break;
                        case "CACHED":
                            Cached = value.ToUpper().Contains("YES") ? true : false;
                            break;

                    }
                }
            }
        }
    }
}