using System;
using SharpStem.Sockets;
using SharpStem.Utils;

namespace SharpStem.test
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Log(LogType.INFO, "meow");

            try
            {
                ControlSocket tryit;
                tryit = new ControlSocket("127.0.0.1", 9051, false);
                tryit.Connect();
                tryit.Send("QUIT\r\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
