using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SharpStem.Sockets
{
    /// <summary>
    /// This class manage to communicate with TOR, low level way.
    /// </summary>
    public class ControlSocket
    {
        public IPAddress Address { get; private set; }
        public uint Port { get; private set; }
        public bool Connected { get; private set; }
        private Socket _socket;

        /// <summary>
        /// Create a ControlSocket instance from a specified control port.
        /// </summary>
        /// <param name="address">The IP address to connect-to (E.G. 192.168.1.1).</param>
        /// <param name="port">The Port number where TOR binded his ControlPort (E.G. 666).</param>
        /// <param name="connect">Connect automatically after the initialization.</param>
        public ControlSocket(string address = "127.0.0.1", uint port = 9051, bool connect = true)
        {
            this.Address = IPAddress.Parse(address);
            this.Port = port;
            _socket = new Socket(SocketType.Stream, ProtocolType.Tcp);

            if (connect)
                this.Connect();
        }

        /// <summary>
        /// Connect to the parameters specified before.
        /// </summary>
        public void Connect()
        {
            if (Connected)
                this.Close();

            _socket.Connect(Address, (int)Port);
            Connected = true;
        }

        /// <summary>
        /// Close the current connection.
        /// </summary>
        public void Close()
        {
            if (Connected)
                _socket.Close();
            else
                throw new SocketNotConnectedException();

            Connected = false;
        }

        /// <summary>
        /// Send a message to the TOR
        /// </summary>
        /// <param name="message">The message to send-to TOR.</param>
        public void Send(string message)
        {
            _socket.Send(Encoding.ASCII.GetBytes(message));
        }

        public string Receive()
        {
            byte[] buffer = new byte[_socket.Available];
            _socket.Receive(buffer);
            return Encoding.ASCII.GetString(buffer);
        }

        //private string Format(string message)
        //{
        //    //From control-spec section 2.2...
        //    //  Command = Keyword OptArguments CRLF / "+" Keyword OptArguments CRLF CmdData
        //    //  Keyword = 1*ALPHA
        //    //  OptArguments = [ SP *(SP / VCHAR) ]

        //    //A command is either a single line containing a Keyword and arguments, or a
        //    //multiline command whose initial keyword begins with +, and whose data
        //    //section ends with a single "." on a line of its own.

        //    //if we already have \r\n entries then standardize on \n to start with

        //    message = message.Replace("\r\n", "\n");

        //    if (message.Contains("\n"))
        //        return "+" + message.Replace("\n", "\r\n") + "\r\n.\r\n";
        //    else
        //        return message + "\r\n";
        //}

        ~ControlSocket()
        {
            if (Connected)
                this.Close();
        }
    }
}
