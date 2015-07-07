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
        /// The int code returned by TOR, when it can't be
        /// handled by the enum
        /// </summary>
        public int RawCode { get; protected set; }

        /// <summary>
        /// Returns the raw string replied by TOR
        /// </summary>
        /// <returns>The raw string replied by TOR</returns>
        public virtual string RawString { get; protected set; }


        public Reply(ReplyCodes code, string raw, int rawcode = -1)
        {
            this.Code = code;
            if (code == ReplyCodes.UNKNOWN)
                this.RawCode = rawcode;

            this.RawString = raw;
        }
    }
}
