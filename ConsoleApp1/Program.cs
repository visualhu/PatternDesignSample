using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            InvokeListTest.Run();

            InvokeListEvolutionTest.Run();

            EventMonitorSimulate.Run();

            RawGenericFactoryTest.Run();

            Console.Read();
        }
    }
}
