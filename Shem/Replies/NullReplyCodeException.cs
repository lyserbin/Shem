using System;

namespace Shem.Replies
{
    public class NullReplyCodeException : Exception {

        public NullReplyCodeException(string message) : base (message) { }
    }
}
