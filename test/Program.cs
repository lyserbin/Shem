using System;
using Shem.Commands;
using Shem.Utils;
using Shem.Replies;

namespace Shem.test
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.LogLevel = LogType.DEBUG;

            try
            {
                TorController tryit;
                Reply testit;

                tryit = new TorController("127.0.0.1", 9051);
                testit = tryit.SendCommand(new AUTHENTICATE("test"));
                tryit.SendRawCommand(new SIGNAL(Signals.HEARTBEAT));
                tryit.SendRawCommand(new GETINFO(Informations.version, Informations.status_clients_seen));
                tryit.SendRawCommand(new GETCONF(Configs.ORPort));
                tryit.SendCommand(new SETCONF(Configs.SocksPort, "9052"));
            }
            catch (Exception ex)
            {
                Logger.Log(LogType.ERROR, ex.Message);
            }

            Console.ReadKey();
        }
    }
}
