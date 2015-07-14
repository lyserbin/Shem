using System;

namespace Shem.Exceptions
{
    class BadTorReplyException : Exception
    {
        public override string Message
        {
            get { return "The server returned a wrong response for the requested config."; }
        }
    }
}
