using Shem.Replies;
using Shem.Utils;

namespace Shem.AsyncEvents
{
    public class BuildTimeoutSetEvent : TorEvent
    {
        public BuildTimeoutSetEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.BUILDTIMEOUT_SET; }
        }

        /// <summary>
        /// 
        /// </summary>
        public BuildTimeoutSetTypes Type
        {
            get;
            protected set;
        }

        /// <summary>
        /// Count of timeouts stored
        /// </summary>
        public int TimeoutsCount
        {
            get;
            protected set;
        }

        /// <summary>
        /// Timeout in milliseconds
        /// </summary>
        public int Timeout
        {
            get;
            protected set;
        }

        /// <summary>
        /// Estimated integer Pareto parameter Xm in milliseconds
        /// </summary>
        public int Xm
        {
            get;
            protected set;
        }

        /// <summary>
        /// Estimated floating point Paredo paremter alpha
        /// </summary>
        public string Alpha
        {
            get;
            protected set;
        }

        /// <summary>
        /// Floating point CDF quantile cutoff point for this timeout
        /// </summary>
        public string Quantile
        {
            get;
            protected set;
        }

        /// <summary>
        /// Floating point ratio of circuits that timeout
        /// </summary>
        public string TimeoutRate
        {
            get;
            protected set;
        }

        /// <summary>
        /// How long to keep measurement circs in milliseconds
        /// </summary>
        public int CloseTimeout
        {
            get;
            protected set;
        }

        /// <summary>
        /// Floating point ratio of measurement circuits that are closed
        /// </summary>
        public string CloseRate
        {
            get;
            protected set;
        }

        protected override void ParseToEvent(Reply reply)
        {
            base.ParseToEvent(reply);

            int index = 0;
            string[] split = EventLine.Split(' ');

            Type = Utility.ParseEnum<BuildTimeoutSetTypes>(split[index]);
            index++;

            for (int i = index; i < split.Length; i++)
            {
                if (split[i].Contains("="))
                {
                    string key = split[i].Split('=')[0];
                    string value = split[i].Split('=')[1];

                    switch (key.ToUpper())
                    {
                        case "TOTAL_TIMES":
                            int tc = 0;
                            int.TryParse(value, out tc);
                            TimeoutsCount = tc;
                            break;
                        case "TIMEOUT_MS":
                            int t = 0;
                            int.TryParse(value, out t);
                            Timeout = t;
                            break;
                        case "XM":
                            int xm = 0;
                            int.TryParse(value, out xm);
                            Xm = xm;
                            break;
                        case "ALPHA":
                            Alpha = value;
                            break;
                        case "CUTOFF_QUANTILE":
                            Quantile = value;
                            break;
                        case "TIMEOUT_RATE":
                            TimeoutRate = value;
                            break;
                        case "CLOSE_MS":
                            int ct = 0;
                            int.TryParse(value, out ct);
                            CloseTimeout = ct;
                            break;
                        case "CLOSE_RATE":
                            CloseRate = value;
                            break;
                    }
                }
            }
        }
    }
}