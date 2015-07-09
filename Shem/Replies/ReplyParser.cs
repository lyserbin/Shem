using System;
using System.Collections.ObjectModel;
using Shem.Exceptions;
using Shem.Utils;

namespace Shem.Replies
{
    /// <summary>
    /// Static class used to parse replies
    /// </summary>
    static class ReplyParser
    {
        // i is the position, named i only cause is shorter to write.
        private static void rparse(string rawstring, int i, ref Collection<Reply> current)
        {
            int tmpcode;
            ReplyCodes code;
            string replyline = "";
            bool tmpres = int.TryParse(rawstring.Substring(i, i + 3), out tmpcode);
            
            if (rawstring.Length < i + 3 || !tmpres)
                throw new NullReplyCodeException(rawstring, i);
            
            i += 4; // skip one char (' ' OR '-')
            while (i < rawstring.Length)
            {
                if (rawstring[i] == '\r' && rawstring[i+1] == '\n')
                {
                    tmpres = Enum.TryParse<ReplyCodes>(tmpcode.ToString(), out code);
                    if (!tmpres) // TODO: not working, fix this.
                        Logger.LogWarn(string.Format("Reply code not identified \"{0}\" in \"{1}\"", tmpcode, rawstring));
                    current.Add(new Reply(code, replyline, rawstring, tmpcode));
                    if (i + 2 == rawstring.Length) // we are @ the end
                        return;
                    else // another ride BABY
                        rparse(rawstring, i + 2, ref current);
                }

                replyline += rawstring[i++];
            }
        }

        /// <summary>
        /// Parse a reply from the tor deamon
        /// </summary>
        /// <param name="rawstring">The string the server replied</param>
        /// <returns>A collection of replies (IT COULD BE EMPTY)</returns>
        public static Collection<Reply> Parse(string rawstring)
        {
            Collection<Reply> replies = new Collection<Reply>();

            rparse(rawstring, 0, ref replies);

            return replies;
        }
    }
}
