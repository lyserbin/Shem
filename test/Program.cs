﻿using System;
using Shem.Commands;
using Shem.Utils;
using Shem.Replies;
using System.Collections.ObjectModel;
using System.Net.Sockets;

namespace Shem.test
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.ConsoleLogLevel = LogTypes.DEBUG;
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
                if(tc.Authenticate(password))
                {
                    Console.WriteLine("Authenticated successfully!");
                }
                else
                {
                    Console.WriteLine("Wrong password.");
                }
                tc.Close();
            }
            catch (SocketException iwontuseit)
            {
                Console.WriteLine("Can't connect to the server at \"{0}:{1}\"", hostname, port);
            }

            Console.ReadKey();
        }
    }
}
