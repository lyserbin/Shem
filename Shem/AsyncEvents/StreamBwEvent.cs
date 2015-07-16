using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class StreamBwEvent : TorEvent
    {
        public StreamBwEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.STREAM_BW; }
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

        protected override void ParseToEvent(Reply reply)
        {
            base.ParseToEvent(reply);

            var split = EventLine.Split(' ');

            ID = split[0];

            int br = 0;
            int.TryParse(split[1], out br);
            BytesRead = br;

            int bw = 0;
            int.TryParse(split[2], out bw);
            BytesWritten = bw;
        }
    }
}