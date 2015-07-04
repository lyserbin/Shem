using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpStem.Sockets
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
