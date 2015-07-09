using System;

namespace Shem.Exceptions
{
    /// <summary>
    /// The ControlSocket isn't connected to TOR.
    /// </summary>
    public class SocketNotConnectedException : Exception
    {
        /// <summary>
        /// The exception message.
        /// </summary>
        public override string Message
        {
            get { return "Non-existent connection."; }
        }
    }
}
