using Shem.Replies;
using Shem.Utils;

namespace Shem.AsyncEvents
{
    public class StreamEvent : TorEvent
    {
        public StreamEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.STREAM; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string StreamID
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public StreamStatus Status
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string CircuitID
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Target
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public StreamReason Reason
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public StreamReason RemoteReason
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Source
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string SourceAddr
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public StreamPurpose Purpose
        {
            get;
            protected set;
        }

        protected override void ParseToEvent(Reply reply)
        {
            base.ParseToEvent(reply);

            int index = 0;
            string[] split = EventLine.Split(' ');

            StreamID = split[index];
            index++;

            Status = Utility.ParseEnum<StreamStatus>(split[index]);
            index++;

            CircuitID = split[index];
            index++;

            Target = split[index];
            index++;

            for (int i = index; i < split.Length; i++)
            {
                if (split[i].Contains("="))
                {
                    string key = split[i].Split('=')[0];
                    string value = split[i].Split('=')[1];

                    switch (key.ToUpper())
                    {
                        case "PURPOSE":
                            Purpose = Utility.ParseEnum<StreamPurpose>(value);
                            break;
                        case "SOURCE_ADDR":
                            SourceAddr = value;
                            break;
                        case "SOURCE":
                            Source = value;
                            break;
                        case "REMOTE_REASON":
                            RemoteReason = Utility.ParseEnum<StreamReason>(value);
                            break;
                        case "REASON":
                            Reason = Utility.ParseEnum<StreamReason>(value);
                            break;
                    }
                }
            }
        }
    }
}