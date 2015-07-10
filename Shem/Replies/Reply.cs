using Shem.Exceptions;
using Shem.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shem.Replies
{
    public class Reply
    {
        /// <summary>
        /// 3 digit code returned by TOR
        /// </summary>
        public virtual ReplyCodes Code { get; protected set; }

        /// <summary>
        /// The actual reply from the server
        /// </summary>
        public virtual string ReplyLine { get; protected set; }
        
        /// <summary>
        /// Returns the raw string replied by TOR
        /// </summary>
        /// <returns>The raw string replied by TOR</returns>
        public virtual string RawString { get; protected set; }

        protected Reply(ReplyCodes code, string replyline, string raw)
        {
            this.Code = code;
            this.ReplyLine = replyline;
            this.RawString = raw;
        }

        protected Reply(Reply reply)
        {
            this.Code = reply.Code;
            this.ReplyLine = reply.ReplyLine;
            this.RawString = reply.RawString;
        }

        /// <summary>
        /// Parse a reply from the tor deamon
        /// </summary>
        /// <param name="rawstring">The string the server replied</param>
        /// <returns>A list of replies (IT COULD BE EMPTY)</returns>
        public static List<Reply> Parse(string rawstring)
        {
            List<Reply> replies = new List<Reply>();

            rparse(rawstring, 0, ref replies);

            return replies;
        }

        // i is the position, named i only cause is shorter to write.
        private static void rparse(string rawstring, int i, ref List<Reply> current)
        {
            int tmpcode;
            ReplyCodes code;
            StringBuilder replyline = new StringBuilder();

            if ((rawstring.Length < i + 3) || (!int.TryParse(rawstring.Substring(i, i + 3), out tmpcode)))
                throw new NullReplyCodeException(rawstring, i); // if the current reply is < 3 chars or has not a code

            i += 4; // skip one char (' ' OR '-')
            while (i < rawstring.Length)
            {
                if (rawstring[i] == '\r' && rawstring[i + 1] == '\n') // we reached the end of the current reply
                {
                    if (!Enum.IsDefined(typeof(ReplyCodes), tmpcode)) // if not in the enum
                        Logger.LogWarn(string.Format("Reply code not identified \"{0}\" in \"{1}\"", tmpcode, rawstring.Replace("\r\n", "\\r\\n")));

                    code = (ReplyCodes)tmpcode;
                    current.Add(new Reply(code, replyline.ToString(), rawstring)); // Add the reply to the return collection
                    if (i + 2 == rawstring.Length) // we are at the end of the string (if it is a multi response one)
                        return;
                    else // another ride BABY
                        rparse(rawstring, i + 2, ref current); // We are not at the end of the string (if it is a multi response one)
                }

                replyline.Append(rawstring[i++]);
            }
        }
    }
}
