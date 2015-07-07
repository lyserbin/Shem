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
            Logger.ConsoleLogLevel = LogType.DEBUG;
            Logger.FileLogLevel = LogType.DEBUG;

            try
            {
                TorController tc;
                Collection<Reply> replies;

                tc = new TorController("127.0.0.1", 9051);
                tc.SendCommand(new AUTHENTICATE("test"));
                replies = tc.SendCommand(new GETINFO(Informations.config_file, Informations.version));
                tc.Close();
            } catch (Exception ex)
            {
                Logger.Log(LogType.ERROR, ex.StackTrace);
            }

            Console.ReadKey();
        }
    }
}
