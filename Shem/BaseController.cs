using System;
using System.Collections.Generic;
using System.Threading;
using Shem.AsyncEvents;
using Shem.Commands;
using Shem.Replies;
using Shem.Sockets;
using Shem.Exceptions;

namespace Shem
{
    /// <summary>
    /// This class is the first interface to the control port.
    /// If you wanna do things in the right way use the 'TorController'
    /// class instead.
    /// </summary>
    public abstract class BaseController : IDisposable
    {
        /// <summary>
        /// Contains type of reply which is currently received. 
        /// </summary>
        private bool _receiveData;

        /// <summary>
        /// Reply which is currently constrocted from received data.
        /// </summary>
        private Reply _currentReply;

        /// <summary>
        /// Socket which receives data from TOR.
        /// </summary>
        private ControlSocket _controlSocket;

        /// <summary>
        /// FIFO buffer for received regular replies.
        /// </summary>
        private Queue<Reply> _replyBuffer;

        /// <summary>
        /// Eventhandle which signals the receiving of a regular reply.
        /// </summary>
        private EventWaitHandle _replyReceivedHdl;

        /// <summary>
        /// The time (in milliseconds) the library should wait for a reply.
        /// </summary>
        protected uint ResponseTimeout { get; set; }

        /// <summary>
        /// Is the Controller connected to the server.
        /// </summary>
        protected bool Connected
        {
            get { return _controlSocket != null ? _controlSocket.Connected : false; } // Null reference exception sucks balls.
        }

        /// <summary>
        /// Construct a new TorController, used to control TOR
        /// </summary>
        /// <param name="address">The address where the ControlPort is (usually localhost)</param>
        /// <param name="port">The port where TOR has binded the ControlPort</param>
        /// <param name="connect">If the controller should connect just after the initialization</param>
        protected BaseController(string address = "127.0.0.1", uint port = 9051, bool connect = true)
        {
            _receiveData = false;
            ResponseTimeout = 1000;

            _controlSocket = new ControlSocket(address, port, connect);
            _controlSocket.OnLineReceived += ControlSocket_OnLineReceived;

            _replyReceivedHdl = new EventWaitHandle(false, EventResetMode.AutoReset);

            _replyBuffer = new Queue<Reply>();
        }

        /// <summary>
        /// Handle a single line which was received by the ControlSocket.
        /// </summary>
        /// <param name="line">Received line (ending with CRLF)</param>
        private void ControlSocket_OnLineReceived(string line)
        {
            if(_receiveData)
            {
                if (line.Length > 0)
                {
                    if (line[0] == '.')
                    {
                        if (line == ".\r\n")
                        {
                            // terminating sequence received
                            // RFC2821: If the line is composed of a single period, it is
                            //          treated as the end of mail indicator.
                            _receiveData = false;
                            HandleFinishedReply();
                            return;
                        }
                        else
                        {
                            // escaped line received
                            // RFC2821: If the first character is a period and there are 
                            //          other characters on the line, the first character 
                            //          is deleted
                            line = line.Substring(1);
                        }
                    }
                }

                _currentReply.RawString += line;
            }
            else
            {
                _currentReply = new Reply(line);

                if ((line[3] == ' ') || // EndReply
                   (line[3] == '-'))   // MidReply
                {
                    HandleFinishedReply();
                }
                else if (line[3] == '+') // DataReply
                {
                    _receiveData = true;
                }
                else
                {
                    throw new NullReplyCodeException(line, 3);
                }
            }
        }

        /// <summary>
        /// Handle a completely received reply.
        /// </summary>
        private void HandleFinishedReply()
        {
            if (((int)_currentReply.Code >= 600) && ((int)_currentReply.Code < 700))
            {
                // reply is async if first number in reply code is 6
                AsyncEventDispatcher(TorEvent.Parse(_currentReply));
            }
            else
            {
                // all other replies are defined as synchronous
                lock (_replyBuffer)
                {
                    _replyBuffer.Enqueue(_currentReply);
                }

                _replyReceivedHdl.Set();
            }
        }

        /// <summary>
        /// Send a command and returns all replies
        /// </summary>
        /// <param name="command">The command to be sent</param>
        /// <returns>List of all received replies</returns>
        public virtual List<Reply> SendCommand(TCCommand command)
        {
            _controlSocket.Send(command.Raw());

            List<Reply> replies = new List<Reply>();

            // receive replies until we get an end reply
            for (;;)
            {
                lock (_replyBuffer)
                {
                    while (_replyBuffer.Count > 0)
                    {
                        Reply reply = _replyBuffer.Dequeue();
                        replies.Add(reply);
                        if (reply.RawString[3] == ' ')
                        {
                            // end reply received --> finished
                            return replies;
                        }
                    }
                }
#if DEBUG
                if (!_replyReceivedHdl.WaitOne())
#else
                if(!_replyReceivedHdl.WaitOne((int)ResponseTimeout))
#endif
                {
                    throw new TimeoutException("Timeout while receiving replies");
                }
            }
        }

        protected abstract void AsyncEventDispatcher(TorEvent asyncEvent);

        /// <summary>
        /// Connect to the control port.
        /// </summary>
        protected void Connect()
        {
            _controlSocket.Connect();
        }

        /// <summary>
        /// Close the socket connection.
        /// Is a good idea to call it before your program exits.
        /// </summary>  
        public virtual void Close()
        {
            if (Connected)
            {
                SendCommand(new Quit());
                _controlSocket.Close();
            }
        }

        public void Dispose(bool disposing)
        {
            Close();

            if (disposing)
            {
                _controlSocket.Dispose();
                _controlSocket = null;
                _replyReceivedHdl.Dispose();
                _replyReceivedHdl = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        ~BaseController()
        {
            Dispose(false);
        }
    }
}