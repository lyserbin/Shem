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
        /// Returns the raw string replied by TOR
        /// </summary>
        /// <returns>The raw string replied by TOR</returns>
        public virtual string RawString { get; protected set; }

        internal Reply(ReplyCodes code, string replyline, string raw)
        {
            this.Code = code;
            this.ReplyLine = replyline;
            this.RawString = raw;
        }

        internal Reply(Reply reply)
        {
            this.Code = reply.Code;
            this.ReplyLine = reply.ReplyLine;
            this.RawString = reply.RawString;
        }
    }
}
