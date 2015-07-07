using System;
using System.Collections.ObjectModel;
using Shem.Exceptions;

namespace Shem.Replies
{
    static class ReplyParser
    {
        private static void rparse(string rawstring, int i, ref Collection<Reply> current)
        {
            int tmpcode = 0;
            ReplyCodes code;
            string replyline = "";

            if (rawstring.Length < i + 3 && !int.TryParse(rawstring.Substring(i, i + 3), out tmpcode))
                throw new NullReplyCodeException(rawstring, i);

            i += 4; // skip one char (' ' OR '-')
            while (i < rawstring.Length)
            {
                if (rawstring[i] == '\r' && rawstring[i+1] == '\n')
                {
                    Enum.TryParse<ReplyCodes>(tmpcode.ToString(), out code);
                    current.Add(new Reply(code, replyline, rawstring, tmpcode));
                    if (i + 2 == rawstring.Length) // we are @ the end
                        return;
                    else // another ride BABY
                        rparse(rawstring, i + 2, ref current);
                }

                replyline += rawstring[i++];
            }
        }

        public static Collection<Reply> Parse(string rawstring)
        {
            Collection<Reply> replies = new Collection<Reply>();

            rparse(rawstring, 0, ref replies);

            return replies;
        }
    }
}
