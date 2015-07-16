using Shem.Replies;

namespace Shem.AsyncEvents
{
    /// <summary>
    /// Our set of guard nodes has changed
    /// </summary>
    public class GuardEvent : TorEvent
    {
        public GuardEvent()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public string Type
        {
            get;
            protected set;
        }

        /// <summary>
        /// Identifies the guard affected
        /// </summary>
        public string Name
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Status
        {
            get;
            protected set;
        }

        public override TorEvents Event
        {
            get { return TorEvents.GUARD; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            base.ParseToEvent(reply);

            string[] split = EventLine.Split(' ');

            Type = split[0];

            Name = split[1];

            Status = split[2];
        }
    }
}