using System;
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
        public virtual string ReplyLine
        {
            get
            {
                if(RawString.Length >= 6)
                {
                    // remove 4 for chars (reply code)
                    return RawString.Substring(4, RawString.Length - 6);
                }
                return "";
            }
        }

        /// <summary>
        /// Returns the raw string replied by TOR
        /// </summary>
        public virtual string RawString { get; internal set; }

        /// <summary>
        /// Create a reply from the raw string replied by TOR
        /// </summary>
        /// <exception cref="Shem.Exceptions.NullReplyCodeException">Thrown when raw string is to short or does
        /// not contain a reply code at the beginning.</exception>
        /// <param name="rawstring">Raw string replied by TOR</param>
        internal Reply(string rawstring)
        {
            int code;
            if ((rawstring.Length < 4) || // 4 chars need for replycode + reply type
                (!int.TryParse(rawstring.Substring(0, 3), out code))) // or the first 3 chars are NOT a 3 digit number
            {
                throw new NullReplyCodeException(rawstring, 0);
            }
            this.Code = (ReplyCodes)code;
            this.RawString = rawstring;
        }

        /// <summary>
        /// Create a reply as copy of another.
        /// </summary>
        /// <param name="reply">Reply to copy from.</param>
        protected Reply(Reply reply)
        {
            this.RawString = reply.RawString;
            this.Code = reply.Code;
        }
    }
}
