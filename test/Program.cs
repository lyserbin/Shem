using System;
using Shem.Commands;
using Shem.Utils;

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

                tryit = new TorController("127.0.0.1", 9051);
                tryit.SendRawCommand(new AUTHENTICATE("test"));
                tryit.SendRawCommand(new SIGNAL(SIGNAL.Signals.HEARTBEAT));
                tryit.SendRawCommand(new GETINFO(GETINFO.Keywords.version, GETINFO.Keywords.config_text));
                tryit.SendRawCommand(new GETCONF("Log", "SocksPort"));
            }
            catch (Exception ex)
            {
                Logger.Log(LogType.ERROR, ex.Message);
            }

            Console.ReadKey();
        }
    }
}
