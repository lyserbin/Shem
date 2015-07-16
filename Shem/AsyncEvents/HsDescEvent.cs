
using Shem.Utils;
namespace Shem.AsyncEvents
{
    public class HsDescEvent : TorEvent
    {
        public HsDescEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.HS_DESC; }
        }

        /// <summary>
        /// 
        /// </summary>
        public HsDescActions Action
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
        public HsDescAuthTypes AuthType
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
        public string DescriptorID
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Reason
        {
            get;
            protected set;
        }

        protected override void ParseToEvent(Replies.Reply reply)
        {
            base.ParseToEvent(reply);

            int index = 0;
            string[] split = EventLine.Split(' ');

            Action = Utility.ParseEnum<HsDescActions>(split[index]);
            index++;

            Address = split[index];
            index++;

            AuthType = Utility.ParseEnum<HsDescAuthTypes>(split[index]);
            index++;

            Name = split[index];
            index++;

            if (!split[index].Contains("="))
            {
                DescriptorID = split[index];
                index++;
            }

            for (int i = index; i < split.Length; i++)
            {
                if (split[i].Contains("="))
                {
                    string key = split[i].Split('=')[0];
                    string value = split[i].Split('=')[1];

                    switch (key.ToUpper())
                    {
                        case "REASON":
                            Reason = value;
                            break;
                    }
                }
            }
        }
    }
}