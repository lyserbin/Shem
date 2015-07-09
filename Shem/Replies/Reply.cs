using System;

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
        /// The int code returned by TOR, when it can't be
        /// handled by the enum
        /// </summary>
        public virtual int RawCode { get; protected set; }

        /// <summary>
        /// Returns the raw string replied by TOR
        /// </summary>
        /// <returns>The raw string replied by TOR</returns>
        public virtual string RawString { get; protected set; }

        internal Reply(ReplyCodes code, string replyline, string raw, int rawcode = -1)
        {
            this.Code = code;
            this.ReplyLine = replyline;
            if (this.Code == ReplyCodes.UNKNOWN)
                this.RawCode = rawcode;

            this.RawString = raw;
        }

        internal Reply(Reply reply)
        {
            this.Code = reply.Code;
            this.ReplyLine = reply.ReplyLine;
            if (this.Code == ReplyCodes.UNKNOWN)
                this.RawCode = reply.RawCode;

            this.RawString = reply.RawString;
        }
    }
}
