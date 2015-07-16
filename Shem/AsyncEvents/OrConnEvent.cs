using Shem.Replies;
using Shem.Utils;

namespace Shem.AsyncEvents
{
    public class OrConnEvent : TorEvent
    {
        public OrConnEvent()
        {

        }

        public override TorEvents Event
        {
            get { return TorEvents.ORCONN; }
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
        public OrConnStatus Status
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public OrConnReasons Reason
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public int CircuitsCount
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string ID
        {
            get;
            protected set;
        }

        protected override void ParseToEvent(Reply reply)
        {
            base.ParseToEvent(reply);

            int index = 0;
            string[] split = EventLine.Split(' ');

            Target = split[index];
            index++;

            Status = Utility.ParseEnum<OrConnStatus>(split[index]);
            index++;

            for (int i = index; i < split.Length; i++)
            {
                if (split[i].Contains("="))
                {
                    string key = split[i].Split('=')[0];
                    string value = split[i].Split('=')[1];

                    switch (key.ToUpper())
                    {
                        case "REASON":
                            Reason = Utility.ParseEnum<OrConnReasons>(value);
                            break;
                        case "NCIRCS":
                            CircuitsCount = int.Parse(value);
                            break;
                        case "ID":
                            ID = value;
                            break;
                    }
                }
            }
        }
    }
}