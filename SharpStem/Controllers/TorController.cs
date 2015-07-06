using System.Threading;
using SharpStem.Protocols.TC;
using SharpStem.Sockets;
namespace SharpStem.Controllers
{
    public class TorController
    {
        private ControlSocket controlSocket;

        private int sleep = 10;

        private int responseTimeout = 1000;
        public int ResponseTimeout
        {
            get { return responseTimeout; }
            set { responseTimeout = value; }
        }


        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        public TorController(string address = "127.0.0.1", uint port = 9051)
        {
            controlSocket = new ControlSocket(address, port);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public string SendCommand(TCCommand command)
        {
            //Send the command
            controlSocket.Send(command.Raw());
            //Wait for response
            int timeout = ResponseTimeout / sleep;
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
        /// TODO
        /// </summary>
        public void Close()
        {
            controlSocket.Close();
        }

        ~TorController()
        {
            controlSocket.Close();
        }
    }
}
