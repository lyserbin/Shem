using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Shem.AsyncEvents;
using Shem.Commands;
using Shem.Replies;
using Shem.Utils;

namespace Shem.test
{
    class Program
    {
        public static LogTypes List { get; set; }

        static void Main(string[] args)
        {
            TorController tc;
            uint port;
            string hostname, password, tmp;
            List<GetInfoReply> infos;
            List<GetConfReply> configs;

            Logger.ConsoleLogLevel = LogTypes.NONE;
            Logger.FileLogLevel = LogTypes.INFO;

            hostname = "127.0.0.1"; // NOTE: ipv6 is NOT supported.
            port = 9051;
            password = "test";

            try
            {

                /* testing
                Console.Write("Write the server host: ");
                hostname = Console.ReadLine();
                Console.Write("Insert your freaking control port: ");
                tmp = Console.ReadLine();
                if(!uint.TryParse(tmp, out port))
                {
                    Console.WriteLine("BAD BOY.");
                    return;
                }
                Console.Write("Enter your password: ");
                password = Console.ReadLine();
                */

                tc = new TorController(hostname, port);

                tc.OnAsyncEvents += tc_OnAsyncEvents;

                if (tc.Authenticate(password))
                {
                    Console.WriteLine("Authenticated successfully!");

                    tc.SendCommand(new SetEvents(false, TorEvents.ORCONN));

                    #region Infos
                    if (tc.GetInfo(out infos,
                                   Informations.process_pid,
                                   Informations.version,
                                   Informations.traffic_read,
                                   Informations.traffic_written
                                   )
                        .Code == ReplyCodes.OK)
                    {
                        foreach (GetInfoReply info in infos)
                        {
                            Console.WriteLine("[INFORMATION] {0} -> {1}", info.Name, info.Value);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong retrieving the informations..."); // should never happen.
                    }
                    #endregion

                    #region Configs
                    tc.GetConf(out configs,
                               Configs.NewCircuitPeriod,
                               Configs.ORPort,
                               Configs.NumEntryGuards,
                               Configs.CookieAuthentication,
                               Configs.ControlSocket);
                    foreach(GetConfReply conf in configs)
                    {
                        Console.WriteLine("[CONFIG] {0} -> {1}", conf.Name, conf.Value==null?"null":conf.Value);
                    }
                    #endregion

                    Console.WriteLine("[CURRENT CONFIG]:\r\n{0}\r\n\r\n",tc.GetCurrentConfig());
                }
                else
                {
                    Console.WriteLine("Wrong password.");
                }

                //Console.WriteLine("Press a key to close the connection.");
                Console.ReadKey();

                tc.Close();
            }
            catch (SocketException)
            {
                Console.WriteLine("Can't connect to the server at \"{0}:{1}\".", hostname, port);
            }

            Console.WriteLine("Press a key to close the program.");
            Console.ReadKey();
        }

        private static void tc_OnAsyncEvents(TorEvent obj)
        {
            Console.WriteLine(string.Format("[EVENT] {0} -> {1}", obj.Event, obj.EventLine));
        }
    }
}