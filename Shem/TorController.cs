using System.Threading;
using Shem.Commands;
using Shem.Sockets;

namespace Shem
{
    /// <summary>
    /// This class is the main class of the library, it is used to
    /// manage tor through easy-to-use functions
    /// </summary>
    public class TorController
    {
        private ControlSocket controlSocket;

        private int sleep = 10;

        private uint responseTimeout = 1000;

        /// <summary>
        /// The time the library should wait for a reply
        /// </summary>
        public uint ResponseTimeout
        {
            get { return responseTimeout; }
            set { responseTimeout = value; }
        }


        /// <summary>
        /// Construct a new TorController, used to control TOR
        /// </summary>
        /// <param name="address">The address where the ControlPort is (usually localhost)</param>
        /// <param name="port">The port where TOR has binded the ControlPort</param>
        /// <param name="connect">If the controller should connect just after the initialization</param>
        public TorController(string address = "127.0.0.1", uint port = 9051, bool connect = true)
        {
            controlSocket = new ControlSocket(address, port, connect);
        }

        /// <summary>
        /// Send a command and returns the reply as a raw string
        /// </summary>
        /// <param name="command">The command to be sent</param>
        /// <returns>Returns the raw string replied by the server</returns>
        public string SendRawCommand(TCCommand command)
        {
            //Send the command
            controlSocket.Send(command.Raw());
            //Wait for response
            int timeout = (int)ResponseTimeout / sleep;
            int i = 1;
            while (!controlSocket.ResponseAvailable && i < timeout)
            {
                Thread.Sleep(sleep);
                i++;
            }
            //Read Response
            return controlSocket.Receive();
        }

        /// <summary>
        /// Connect to the control port.
        /// </summary>
        public void Connect()
        {
            controlSocket.Connect();
        }

        /// <summary>
        /// Close the socket connection.
        /// </summary>  
        public void Close()
        {
            controlSocket.Close();
        }

        ~TorController()
        {
            if(controlSocket.Connected)
                Close();
        }
    }
}
