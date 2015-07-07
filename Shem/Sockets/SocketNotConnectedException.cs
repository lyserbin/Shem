using System;

namespace Shem.Sockets
{
    /// <summary>
    /// The ControlSocket isn't connected to TOR.
    /// </summary>
    public class SocketNotConnectedException : Exception
    {
        public override string Message
        {
            get
            {
                return "Non-existent connection.";
            }
        }
    }
}
