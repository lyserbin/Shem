using System;
using SharpStem.Controllers;
using SharpStem.Protocols.TC.Commands;
using SharpStem.Utils;

namespace SharpStem.test
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
                tryit.SendCommand(new AUTHENTICATE());
                tryit.SendCommand(new SIGNAL(SIGNAL.Signals.HEARTBEAT));
                tryit.SendCommand(new GETINFO("version", "config-file"));
                tryit.SendCommand(new GETCONF("Log", "SocksPort"));
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
