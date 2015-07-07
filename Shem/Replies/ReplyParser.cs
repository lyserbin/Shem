using System;

namespace Shem.Replies
{
    static class ReplyParser
    {
        public static Reply Parse(string rawstring)
        {
            int i = 0, tmp;
            string code = "";
            ReplyCodes rcode;

            while (i < rawstring.Length && int.TryParse(Convert.ToString(rawstring[i++]), out tmp))
            {
                code += tmp;
            }

            if (i == 0)
                throw new NullReplyCodeException(String.Format("No reply code found for \"{0}\".", rawstring));

            if (Enum.TryParse<ReplyCodes>(code, out rcode))
                return new Reply(rcode, rawstring);
            else
                return new Reply(ReplyCodes.UNKNOWN, rawstring, int.Parse(code));
        }
    }
}
