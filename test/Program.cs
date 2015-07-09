using System;
using Shem.Commands;
using Shem.Utils;
using Shem.Replies;
using System.Collections.ObjectModel;

namespace Shem.test
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.ConsoleLogLevel = LogTypes.WARNING;
            Logger.FileLogLevel = LogTypes.INFO;

            try
            {
                TorController tc;
                string password;

                tc = new TorController("127.0.0.1", 9051);
                Console.Write("Enter your password: ");
                password = Console.ReadLine();
                if(tc.Authenticate(password))
                {
                    Console.WriteLine("Authenticated successfully!");
                }
                else
                {
                    Console.WriteLine("Wrong password.");
                }
                tc.Close();
            } catch (Exception ex)
            {
                Logger.LogError(string.Format("{0} {1}",ex.Message, ex.StackTrace));
            }

            Console.ReadKey();
        }
    }
}
