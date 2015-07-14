using System;
using System.Collections.Generic;
using Shem.Replies;
using Shem.Utils;

namespace Shem.AsyncEvents
{
    /// <summary>
    /// 
    /// </summary>
    public class CircEvent : TorEvent
    {
        public CircEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.CIRC; }
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
        public CircStatus Status
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Path
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public List<CircBuildFlags> BuildFlags
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public CircPurpose Purpose
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public CircHsState HsState
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string RendQuery
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string TimeCreated
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public CircReasons Reason
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public CircReasons RemoteReason
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string SocksUsername
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string SocksPassword
        {
            get;
            protected set;
        }

        protected override void ParseToEvent(Reply reply)
        {
            base.ParseToEvent(reply);

            int index = 0;

            string[] split = EventLine.Split(' ');
            ID = split[index];
            index++;

            CircStatus tmpcs = CircStatus.LAUNCHED;
            if (!Enum.TryParse<CircStatus>(split[index], true, out tmpcs))
            {
                Logger.LogWarn("Error during the parsing of CircStatus in CircEvent.");
            }
            Status = tmpcs;
            index++;

            if (!split[index].Contains("="))
            {
                Path = split[index];
                index++;
            }
            else
            {
                Path = "";
            }

            for (int i = index; i < split.Length; i++)
            {
                if (split[i].Contains("="))
                {
                    string key = split[i].Split('=')[0];
                    string value = split[i].Split('=')[1];

                    switch (key.ToUpper())
                    {
                        case "BUILD_FLAGS":
                            List<CircBuildFlags> flags = new List<CircBuildFlags>();
                            foreach (var stringFlag in value.Split(','))
                            {
                                CircBuildFlags tmpbf = CircBuildFlags.IS_INTERNAL;
                                if (!Enum.TryParse<CircBuildFlags>(value, true, out tmpbf))
                                {
                                    Logger.LogWarn("Error during the parsing of CircBuildFlags in CircEvent.");
                                }
                                flags.Add(tmpbf);
                            }
                            BuildFlags = flags;
                            break;
                        case "PURPOSE":
                            CircPurpose tmpp = CircPurpose.GENERAL;
                            if (!Enum.TryParse<CircPurpose>(value, true, out tmpp))
                            {
                                Logger.LogWarn("Error during the parsing of CircPurpose in CircEvent.");
                            }
                            Purpose = tmpp;
                            break;
                        case "HS_STATE":
                            CircHsState tmphs = CircHsState.HSCI_CONNECTING;
                            if (!Enum.TryParse<CircHsState>(value, true, out tmphs))
                            {
                                Logger.LogWarn("Error during the parsing of CircHsState in CircEvent.");
                            }
                            HsState = tmphs;
                            break;
                        case "REND_QUERY":
                            RendQuery = value;
                            break;
                        case "TIME_CREATED":
                            TimeCreated = value;
                            break;
                        case "REASON":
                            CircReasons tmpr = CircReasons.CONNECTFAILED;
                            if (!Enum.TryParse<CircReasons>(value, true, out tmpr))
                            {
                                Logger.LogWarn("Error during the parsing of CircReason in CircEvent.");
                            }
                            Reason = tmpr;
                            break;
                        case "REMOTE_REASON":
                            CircReasons tmprr = CircReasons.CONNECTFAILED;
                            if (!Enum.TryParse<CircReasons>(value, true, out tmprr))
                            {
                                Logger.LogWarn("Error during the parsing of CircReason in CircEvent.");
                            }
                            RemoteReason = tmprr;
                            break;
                        case "SOCKS_USERNAME":
                            SocksUsername = value.Replace("\"", "");
                            break;
                        case "SOCKS_PASSWORD":
                            SocksPassword = value.Replace("\"", "");
                            break;
                    }
                }
            }
        }
    }
}