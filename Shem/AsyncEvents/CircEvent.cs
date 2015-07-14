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

            Status = ParseCircStatus(index, split);

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
                                flags.Add(ParseCircBuildFlags(value));
                            }
                            BuildFlags = flags;
                            break;
                        case "PURPOSE":
                            Purpose = ParseCircPurpose(value);
                            break;
                        case "HS_STATE":
                            HsState = ParseCircHsState(value);
                            break;
                        case "REND_QUERY":
                            RendQuery = value;
                            break;
                        case "TIME_CREATED":
                            TimeCreated = value;
                            break;
                        case "REASON":
                            Reason = ParseCircReason(value);
                            break;
                        case "REMOTE_REASON":
                            RemoteReason = ParseCircReason(value);
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

        private static CircReasons ParseCircReason(string value)
        {
            CircReasons tmpr = CircReasons.CONNECTFAILED;
            if (!Enum.TryParse<CircReasons>(value, true, out tmpr))
            {
                Logger.LogWarn("Error during the parsing of CircReason in CircEvent.");
            }
            return tmpr;
        }

        private static CircHsState ParseCircHsState(string value)
        {
            CircHsState tmphs = CircHsState.HSCI_CONNECTING;
            if (!Enum.TryParse<CircHsState>(value, true, out tmphs))
            {
                Logger.LogWarn("Error during the parsing of CircHsState in CircEvent.");
            }
            return tmphs;
        }

        private static CircPurpose ParseCircPurpose(string value)
        {
            CircPurpose tmpp = CircPurpose.GENERAL;
            if (!Enum.TryParse<CircPurpose>(value, true, out tmpp))
            {
                Logger.LogWarn("Error during the parsing of CircPurpose in CircEvent.");
            }
            return tmpp;
        }

        private static CircBuildFlags ParseCircBuildFlags(string value)
        {
            CircBuildFlags tmpbf = CircBuildFlags.IS_INTERNAL;
            if (!Enum.TryParse<CircBuildFlags>(value, true, out tmpbf))
            {
                Logger.LogWarn("Error during the parsing of CircBuildFlags in CircEvent.");
            }
            return tmpbf;
        }

        private static CircStatus ParseCircStatus(int index, string[] split)
        {
            CircStatus tmpcs = CircStatus.LAUNCHED;
            if (!Enum.TryParse<CircStatus>(split[index], true, out tmpcs))
            {
                Logger.LogWarn("Error during the parsing of CircStatus in CircEvent.");
            }
            return tmpcs;
        }
    }
}