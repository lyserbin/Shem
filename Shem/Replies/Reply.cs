using System;
using System.Collections.Generic;
using System.Text;
using Shem.Exceptions;
using Shem.Utils;

namespace Shem.Replies
{
    public class Reply
    {
        private ReplyCodes _code;

        /// <summary>
        /// 3 digit code returned by TOR
        /// </summary>
        public virtual ReplyCodes Code
        {
            get
            {
                return this._code;
            }
            protected set
            {
                if (!Enum.IsDefined(typeof(ReplyCodes), value))
                    Logger.LogWarn(string.Format("Reply code not identified \"{0}\" in \"{1}\"", value, this.RawString));

                this._code = value;
            }
        }

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
            this.ReplyLine = replyline;
            this.RawString = raw;
            this.Code = code;
        }

        protected Reply(Reply reply)
        {
            this.ReplyLine = reply.ReplyLine;
            this.RawString = reply.RawString;
            this.Code = reply.Code;
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
            int code;
            int j;
            bool multiline;
            StringBuilder replyline;

            j = i; // used for substring the rawstring
            replyline = new StringBuilder();

            if ((rawstring.Length < i + 3) || // the relative string is < 3 chars
                (!int.TryParse(rawstring.Substring(i, 3), out code))) // or the first 3 chars are NOT a 3 digit number
            {
                throw new NullReplyCodeException(rawstring, i);
            }

            multiline = rawstring[i + 3] == '+'; // it is a multiline (multiline ends with ".\r\n");
            i += 4; // we computed the code and the multiline, go ahead BOY!
            
            while (i < rawstring.Length) // while we are on the right way
            {
                bool end;

                end = (multiline && rawstring.Length > i+4 && rawstring.Substring(i, 5) == "\r\n.\r\n") || // we are at the end of a multiline reply
                      (!multiline && rawstring.Length > i+1 && rawstring.Substring(i,2) == "\r\n"); // we are at the end of a singleline reply

                if  (end)
                {
                    i += multiline ? 5 : 2;

                    // Add the reply to the return collection
                    current.Add(new Reply((ReplyCodes)code,
                                          replyline.ToString(),
                                          rawstring.Substring(j, i - j)));

                    int z = rawstring.Length;
                    if (i == rawstring.Length)
                    {
                        return; // we are at the end of the string (if it is a multi response one)
                    }
                    else
                    {
                        rparse(rawstring, i, ref current); // We are not at the end of the string (if it is a multi response one)
                        return;
                    }
                }
                replyline.Append(rawstring[i]);
                i++;
            }

            // THIS SHOULD NEVER EVER EVER HAPPEN
            Logger.LogWarn(String.Format("Reply not parsed well, reached the end of the recursive funciton: \"{0}\".", rawstring));
        }
    }
}
