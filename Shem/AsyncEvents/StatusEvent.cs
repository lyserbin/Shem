using System.Collections.Generic;
using Shem.Replies;
using Shem.Utils;

namespace Shem.AsyncEvents
{
    public abstract class StatusEvent : TorEvent
    {
        public StatusSeverity Severity
        {
            get;
            protected set;
        }

        public string Action
        {
            get;
            protected set;
        }

        public Dictionary<string, string> Arguments
        {
            get;
            protected set;
        }

        protected override void ParseToEvent(Reply reply)
        {
            base.ParseToEvent(reply);

            int index = 0;
            string[] split = EventLine.Split(' ');

            Severity = Utility.ParseEnum<StatusSeverity>(split[index]);
            index++;

            Action = split[index];
            index++;

            Arguments = new Dictionary<string, string>();
            for (int i = index; i < split.Length; i++)
            {
                if (split[i].Contains("="))
                {
                    string key = split[i].Split('=')[0];
                    string value = split[i].Split('=')[1].Replace("\"", "");

                    Arguments.Add(key, value);
                }
            }
        }
    }
}