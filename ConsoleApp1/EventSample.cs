using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class EventMonitor
    {
        public static EventHandler<EventArgs> Modified;
        public static EventHandler<EventArgs> Added;

        static EventMonitor()
        {
            Modified = OnModified;
            Added = OnAdded;
        }

        public static int ModifiedTimes { get; private set; }
        public static int AddedTimes { get; private set; }

        static void OnModified(object sender, EventArgs args)
        {
            ModifiedTimes++;
        }

        static void OnAdded(object sender, EventArgs args)
        {
            AddedTimes++;
        }
    }

    public class OrderService
    {
        public void Create()
        {
            EventMonitor.Added(this, null);
        }

        public void ChangeDate()
        {
            EventMonitor.Modified(this, null);
        }

        public void ChangeOwner()
        {
            EventMonitor.Modified(this, null);
        }

        public void ChangeId()
        {

        }


    }

    public class EventMonitorSimulate
    {
        public static void Run()
        {
            var order1 = new OrderService();
            order1.ChangeDate();
            order1.Create();
            order1.ChangeOwner();


            var order2 = new OrderService();
            order2.Create();
            order2.ChangeDate();
            order2.ChangeOwner();

            Console.WriteLine($"Order Added Times:{EventMonitor.AddedTimes},Order Modified Times:{EventMonitor.ModifiedTimes}");
        }
    }
}