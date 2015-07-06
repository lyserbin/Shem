using System;

namespace Shem.Replies
{
    public abstract class Reply
    {
        /// <summary>
        /// Returns the raw string replied by TOR
        /// </summary>
        /// <returns>The raw string replied by TOR</returns>
        public abstract string RawString();

        /// <summary>
        /// 3 digit code returned by TOR
        /// </summary>
        public abstract ReplyCodes Code { get; }
    }
}
