using System;
using SharpStem.Sockets;

namespace SharpStem.test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("meow");

            try
            {
                ControlSocket tryit;
                tryit = new ControlSocket("127.0.0.1", 9051, false);
                tryit.Connect();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
