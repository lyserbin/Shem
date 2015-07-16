using System.Collections.Generic;
using Shem.Replies;
using Shem.Utils;

namespace Shem.AsyncEvents
{
    public class CircMinorEvent : TorEvent
    {
        public CircMinorEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.CIRC_MINOR; }
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
        public CircPurpose OldPurpose
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public CircHsState OldHsState
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

            Status = Utility.ParseEnum<CircStatus>(split[index]);
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
                                flags.Add(Utility.ParseEnum<CircBuildFlags>(stringFlag));
                            }
                            BuildFlags = flags;
                            break;
                        case "PURPOSE":
                            Purpose = Utility.ParseEnum<CircPurpose>(value);
                            break;
                        case "HS_STATE":
                            HsState = Utility.ParseEnum<CircHsState>(value);
                            break;
                        case "OLD_PURPOSE":
                            OldPurpose = Utility.ParseEnum<CircPurpose>(value);
                            break;
                        case "OLD_HS_STATE":
                            OldHsState = Utility.ParseEnum<CircHsState>(value);
                            break;
                        case "REND_QUERY":
                            RendQuery = value;
                            break;
                        case "TIME_CREATED":
                            TimeCreated = value;
                            break;
                    }
                }
            }
        }
    }
}