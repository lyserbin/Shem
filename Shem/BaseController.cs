using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Shem.Commands;
using Shem.Replies;
using Shem.Sockets;

namespace Shem
{
    /// <summary>
    /// This class is the first interface to the control port.
    /// If you wanna do things in the right way use the 'TorController'
    /// class instead.
    /// </summary>
    public abstract class BaseController
    {

        protected ControlSocket controlSocket;

        protected int sleep = 10;

        protected uint responseTimeout = 1000;

        protected Task asyncEventsListener;

        protected bool asyncEventsListenerStop = false;

        protected bool canListen = false;

        /// <summary>
        /// The time the library should wait for a reply.
        /// </summary>
        protected uint ResponseTimeout
        {
            get { return responseTimeout; }
            set { responseTimeout = value; }
        }
        /// <summary>
        /// Is the Controller connected to the server.
        /// </summary>
        protected bool Connected
        {
            get { return controlSocket != null ? controlSocket.Connected : false; } // Null reference exception sucks balls.
        }


        /// <summary>
        /// Construct a new TorController, used to control TOR
        /// </summary>
        /// <param name="address">The address where the ControlPort is (usually localhost)</param>
        /// <param name="port">The port where TOR has binded the ControlPort</param>
        /// <param name="connect">If the controller should connect just after the initialization</param>
        protected BaseController(string address = "127.0.0.1", uint port = 9051, bool connect = true)
        {
            controlSocket = new ControlSocket(address, port, connect);

            canListen = true;

            asyncEventsListener = Task.Run(() => { ListenForAsyncEvents(); });
        }

        private void ListenForAsyncEvents()
        {
            while (!asyncEventsListenerStop)
            {
                if (canListen)
                {
                    lock (controlSocket)
                    {
                        if (controlSocket.ResponseAvailable)
                        {
                            string rawReply = controlSocket.Receive();
                            AsyncEventDispatcher(Reply.Parse(rawReply));
                        }
                    }
                }
                Task.Delay(250);
            }
        }

        /// <summary>
        /// Send a command and returns the reply as a raw string
        /// </summary>
        /// <param name="command">The command to be sent</param>
        /// <returns>Returns the raw string replied by the server</returns>
        protected string SendRawCommand(TCCommand command)
        {
            string rawReply = "";

            canListen = false;

            lock (controlSocket)
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

                rawReply = controlSocket.Receive();
            }

            canListen = true;

            return rawReply;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        protected List<Reply> SendCommand(TCCommand command)
        {
            List<Reply> replies = Reply.Parse(SendRawCommand(command));
            List<Reply> asyncEvents = new List<Reply>();

            foreach (var r in replies)
            {
                if (r.Code == ReplyCodes.ASYNC_EVENT_NOTIFICATION)
                {
                    asyncEvents.Add(r);
                }
            }

            foreach (var e in asyncEvents)
            {
                replies.Remove(e);
            }

            AsyncEventDispatcher(asyncEvents);

            return replies;
        }

        protected abstract void AsyncEventDispatcher(Reply asyncEvent);

        protected abstract void AsyncEventDispatcher(List<Reply> asyncEvents);

        /// <summary>
        /// Connect to the control port.
        /// </summary>
        protected void Connect()
        {
            controlSocket.Connect();
        }

        /// <summary>
        /// Close the socket connection.
        /// Is a good idea to call it before your program exits.
        /// </summary>  
        public virtual void Close()
        {
            SendRawCommand(new Quit());
            asyncEventsListenerStop = true;
            asyncEventsListener.Wait();
            controlSocket.Close();
        }

        ~BaseController()
        {
            if (Connected)
                Close();
        }
    }
}