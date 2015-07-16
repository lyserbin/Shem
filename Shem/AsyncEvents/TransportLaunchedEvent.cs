
namespace Shem.AsyncEvents
{
    public class TransportLaunchedEvent : TorEvent
    {
        public TransportLaunchedEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.TRANSPORT_LAUNCHED; }
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
        public string Address
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Port
        {
            get;
            protected set;
        }

        protected override void ParseToEvent(Replies.Reply reply)
        {
            base.ParseToEvent(reply);

            string[] split = EventLine.Split(' ');

            Type = split[0];

            Name = split[1];

            Address = split[2];

            Port = split[3];
        }
    }
}