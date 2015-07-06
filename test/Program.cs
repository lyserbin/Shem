using System;
using SharpStem.Sockets;
using SharpStem.Utils;
using System.Threading;

namespace SharpStem.test
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.LogLevel = LogType.DEBUG;

            try
            {
                ControlSocket tryit;
                tryit = new ControlSocket("127.0.0.1", 9051, false);
                tryit.Connect();
                tryit.Send("AUTHENTICATE\r\n");
                Thread.Sleep(100);
                tryit.Receive();
                tryit.Send("SIGNAL HEARTBEAT\r\n");
                Thread.Sleep(100);
                tryit.Receive();
                tryit.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
