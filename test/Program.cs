using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sharp_stem.sockets;

namespace sharp_stem.test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("meow");
            ControlSocket tryit;

            tryit = new ControlSocket();

            Console.ReadKey();
        }
    }
}
