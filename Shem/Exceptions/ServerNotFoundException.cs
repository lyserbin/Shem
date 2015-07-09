using System;

namespace Shem.Exceptions
{
    class ServerNotFoundException : Exception
    {
        public override string Message
        {
            get { return "Can't find the TOR server... Are you sure about the hostname / IP ?"; }
        }
    }
}
