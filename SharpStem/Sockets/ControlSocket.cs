using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

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
        public async void Connect()
        {
            await Connect_Async();
        }

        private async Task Connect_Async()
        {
            if (Connected)
                this.Close();

            _socket.Connect(Address, (int)Port);
            Connected = true;
        }

        /// <summary>
        /// Close the current connection.
        /// </summary>
        public async void Close()
        {
            await Close_Async();
        }

        private async Task Close_Async()
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
        /// <param name="format">If the message should be formatted.</param>
        public void Send(string message, bool format = false)
        {
            if (!format)
                _socket.Send(Encoding.UTF8.GetBytes(message));


        }

        ~ControlSocket()
        {
            this.Close();
        }
    }
}
