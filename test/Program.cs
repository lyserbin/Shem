using System;
using System.Net.Sockets;
using Shem.AsyncEvents;
using Shem.Commands;
using Shem.Utils;

namespace Shem.test
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.ConsoleLogLevel = LogTypes.INFO;
            Logger.FileLogLevel = LogTypes.INFO;

            TorController tc;
            uint port;
            string hostname, password, tmp;


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

                tc.OnAsyncEvent[AsyncEvents.AsyncEvents.DEBUG].Event += Program_Event;

                if (tc.Authenticate(password))
                {
                    Console.WriteLine("Authenticated successfully!");
                }
                else
                {
                    Console.WriteLine("Wrong password.");
                }

                tc.SendCommand(new SetEvents(false, AsyncEvents.AsyncEvents.INFO, AsyncEvents.AsyncEvents.ERR, AsyncEvents.AsyncEvents.DEBUG, AsyncEvents.AsyncEvents.WARN, AsyncEvents.AsyncEvents.NOTICE));

                Console.WriteLine("Press a key to close the connection.");

                Console.ReadKey();

                tc.Close();
            }
            catch (SocketException iwontuseit)
            {
                Console.WriteLine("Can't connect to the server at \"{0}:{1}\"", hostname, port);
            }

            Console.ReadKey();
        }

        static void Program_Event(AsyncEvent obj)
        {
            var debug = (DebugEvent)obj;
            Console.WriteLine("From specific event -> " + debug.Event + " -> " + debug.LogMessage);
        }

        static void tc_OnAsyncEvents(AsyncEvent obj)
        {
            if (obj is LogEvent)
            {
                Console.WriteLine(string.Format("Event -> {0} -> {1}", obj.Event, ((LogEvent)obj).LogMessage));
            }
        }
    }
}
