using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public delegate void StringAssignmentEventHandler();
    public class InvokeList
    {
        List<StringAssignmentEventHandler> handlers;
        string[] message = new string[3];

        public InvokeList()
        {
            handlers = new List<StringAssignmentEventHandler>()
            {
                AppendHello,
                AppendComma,
                AppendWorld
            };
        }

        public string this[int index]
        {
            get { return message[index]; }
        }

        public void Invoke()
        {
            handlers.ForEach(x => x.Invoke());
        }

        public void AppendHello() { message[0] = "Hello"; }
        public void AppendComma(){message[1]=",";}
        public void AppendWorld() { message[2] = "world."; }
    }

    public class InvokeListTest
    {
        public static void Run()
        {
            var list = new InvokeList();
            list.Invoke();
            Console.WriteLine($"{list[0]}{list[1]}{list[2]}");
        }
    }

    public class InvokeListEvolution
    {
        string[] message = new string[3];
        public InvokeListEvolution()
        {
            StringAssignmentEventHandler handler = null;
            handler += delegate { message[0] = "Hello"; };
            handler += () => { message[1] = ","; };
            handler += () => { message[2] = "world."; };
            handler.Invoke();
        }

        public string this[int index]
        {
            get { return message[index]; }
        }

       
    }


    public class InvokeListEvolutionTest
    {
        public static void Run()
        {
            var list = new InvokeListEvolution();

            Console.WriteLine($"{list[0]}{list[1]}{list[2]}");
        }
    }
}
