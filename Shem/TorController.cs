﻿using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;
using Shem.AsyncEvents;
using Shem.Commands;
using Shem.Replies;
using Shem.Utils;
using System.Net;

namespace Shem
{
    public class TorController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        public event Action<TorEvent> OnAsyncEvents;

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<TorEvents, ListableEvents<TorEvent>> OnAsyncEvent = new Dictionary<TorEvents, ListableEvents<TorEvent>>();

        /// <summary>
        /// This is true if we are Authenticated, false if
        /// the authentication failed or you haven't tried
        /// to authenticate yet.
        /// </summary>
        public bool Authenticated { get; private set; }

        /// <summary>
        /// Create a new tor controller, used for control tor
        /// through the control port.
        /// </summary>
        /// <param name="address">The address where you want to connect</param>
        /// <param name="port">The port where the control port is binded</param>
        /// <param name="connect">If this is true the controller will connect automatically to the server after initialization.</param>
        public TorController(string address = "127.0.0.1", uint port = 9051, bool connect = true)
            : base(address, port, connect)
        {
            foreach (var v in Enum.GetValues(typeof(TorEvents)))
            {
                OnAsyncEvent.Add((TorEvents)v, new ListableEvents<TorEvent>());
            }
        }

        /// <summary>
        /// Authenticate with the tor control port.
        /// </summary>
        /// <param name="password">The tor control password NOT-hashed.</param>
        /// <returns>True in case of successful authentication, false in every other case.</returns>
        public bool Authenticate(string password = "")
        {
            if (!this.Connected)
                throw new SocketException();

            AuthenticateReply reply;
            List<Reply> replies;

            replies = SendCommand(new Authenticate(password));
            if (replies.Count < 1)
                return false;

            reply = new AuthenticateReply(replies[0]);
            this.Authenticated = reply.IsAuthenticated();
            Logger.LogInfo(Authenticated ? "Authentication succeded" : "Authentication failed");
            return Authenticated;
        }

        /// <summary>
        /// Writes the requested infos in the passed GetInfoReply list.
        /// </summary>
        /// <param name="output">The list that has to be filled with the requested infos.</param>
        /// <param name="informations">A potentially infinite list of informations to be requested to the server.</param>
        /// <returns>Returns the general response given by the server, it is a good idea to check if it is 250 OK.</returns>
        public Reply GetInfo(out List<GetInfoReply> output, params Informations[] informations)
        {
            List<Reply> replies;

            output = new List<GetInfoReply>();
            replies = SendCommand(new GetInfo(informations));

            for (int i = 0; i < replies.Count - 1; i++)
            {
                output.Add(new GetInfoReply(replies[i]));
            }

            return replies[replies.Count - 1];
        }

        /// <summary>
        /// Writes the requested configs in the passed GetConfReply list.
        /// </summary>
        /// <param name="output">The list that has to be filled with the requested configs.</param>
        /// <param name="informations">A potentially infinite list of informations to be requested to the server.</param>
        public void GetConf(out List<GetConfReply> output, params Configs[] configs)
        {
            List<Reply> replies;

            output = new List<GetConfReply>();
            replies = SendCommand(new GetConf(configs));

            for (int i = 0; i < replies.Count - 1; i++)
            {
                output.Add(new GetConfReply(replies[i]));
            }
        }

        /// <summary>
        /// This functions returns the current run-time edited torrc.
        /// </summary>
        /// <returns>Returns the current configuration of TOR.</returns>
        public string GetCurrentConfig()
        {
            List<GetInfoReply> tmp;
            GetInfo(out tmp, Informations.config_text);
            return tmp[0].ReplyLine;
        }

        public IPAddress Resolve(string address)
        {
            SendCommand(new Resolve(address));
            OnAsyncEvent[TorEvents.ADDRMAP].Event += Resolve_Event;

            // TODO: wait tykonket to implement the ADDRMAP event.
            return null;
        }

        private void Resolve_Event(TorEvent obj)
        {
            // TODO: wait tykonket to implement the ADDRMAP event.
        }

        protected override void AsyncEventDispatcher(TorEvent asyncEvent)
        {
            Task.Run(() =>
            {
                if (OnAsyncEvents != null)
                {
                    OnAsyncEvents.Invoke(asyncEvent);
                }
                if (OnAsyncEvent.ContainsKey(asyncEvent.Event))
                {
                    OnAsyncEvent[asyncEvent.Event].Dispatch(asyncEvent);
                }
            });
        }

        /// <summary>
        /// Close the connection with the control port.
        /// </summary>
        public override void Close()
        {
            base.Close();
        }
    }
}
