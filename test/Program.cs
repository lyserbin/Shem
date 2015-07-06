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
                tryit = new TorController("79.10.194.111", 9051);
                tryit.SendCommand(new AUTHENTICATE("\"test\""));
                tryit.SendCommand(new SIGNAL(SIGNAL.Signals.SHUTDOWN));
                tryit.SendCommand(new GETINFO(GETINFO.Keywords.version, GETINFO.Keywords.config_text));
                //tryit.SendCommand(new GETCONF("Log", "SocksPort"));
                tryit.Close();
            }
            catch (Exception ex)
            {
                Logger.Log(LogType.ERROR, ex.Message);
            }

            Console.ReadKey();
        }
    }
}
