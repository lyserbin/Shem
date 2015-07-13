using Shem.Replies;

namespace Shem.AsyncEvents
{
    /// <summary>
    /// Bandwidth used in the last second
    /// </summary>
    public class BwEvent : TorEvent
    {
        public BwEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.BW; }
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
            if (split.Length > 1)
            {
                int br = 0;
                int.TryParse(split[0], out br);
                BytesRead = br;

                int bw = 0;
                int.TryParse(split[1], out bw);
                BytesWritten = bw;
            }
            if (split.Length > 2)
            {
                //TODO: Implement parsing of additional parameters
            }
        }
    }
}